using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DBXV2NSSaveEditor.DecryptEncrypt
{
    public class Xv2SavFile
    {
        readonly byte[] Section1Key = Encoding.ASCII.GetBytes("PR]-<Q9*WxHsV8rcW!JuH7k_ug:T5ApX");
        readonly byte[] Section1Counter = Encoding.ASCII.GetBytes("_Y7]mD1ziyH#Ar=0");
        readonly uint encrypted_size = 0xB0800;
        readonly uint decrypted_size = 0xB0780;

        public byte[] Load(string sPath)
        {
            byte temp;
            byte[] Section2Key, Section2Counter;

            //switch version has no extra md5 header, it starts directly with the encrypted #SAV section

            using (var br = new BinaryReader(File.OpenRead(sPath)))
            {
                byte[] section1 = br.ReadBytes(0x80);
                section1 = Utils.AesCtrDecrypt(Section1Key, Section1Counter, section1);

                byte[] fileSize = File.ReadAllBytes(sPath);
                if (fileSize.Length != encrypted_size)
                {
                    MessageBox.Show("Encrypted size mismatch. \nYour file size: " + fileSize.Length + "\nProper encrypted file size: " + encrypted_size, "Error");
                    Environment.Exit(1);
                }

                if (section1[0] != 0x23 || section1[1] != 0x53 || section1[2] != 0x41 || section1[3] != 0x56 || section1[4] != 0x00) //#SAV + 0x00
                {
                    MessageBox.Show("Failed at signature of first section.", "Error");
                    Environment.Exit(1);
                }

                byte Checksum1 = section1[0x14];
                byte Checksum2 = section1[0x1B];
                byte Checksum3 = section1[0x19];
                byte Checksum4 = section1[0x18];
                byte Checksum5 = section1[0x17];
                byte Checksum6 = section1[0x16];
                byte Checksum7 = section1[0x15];
                byte Checksum8 = section1[0x1A];

                int section2size = BitConverter.ToInt32(section1, 0x7C);
                byte[] section2 = br.ReadBytes(section2size);

                //Checksum1
                temp = section1[0x5];
                for (int i = 0; i < 7; i++) temp += section1[0x15 + i];
                if (Checksum1 != temp)
                {
                    MessageBox.Show($"Checksum1 failed ({temp} != {Checksum1}).", "Error");
                    Environment.Exit(1);
                }

                //Checksum2
                temp = 0;
                for (int i = 0; i < section2size / 0x20; i++)
                    temp += section2[i * 0x20];
                if (Checksum2 != temp)
                {
                    MessageBox.Show($"Checksum2 failed ({temp} != {Checksum2}).", "Error");
                    Environment.Exit(1);
                }

                //Checksum3
                temp = (byte)(section1[0x6C] + section1[0x70] + section1[0x74] + section1[0x78]);
                if (Checksum3 != temp)
                {
                    MessageBox.Show($"Checksum3 failed ({temp} != {Checksum3}).", "Error");
                    Environment.Exit(1);
                }

                //Checksum4
                temp = (byte)(section1[0x3C] + section1[0x40] + section1[0x44] + section1[0x48]);
                if (Checksum4 != temp)
                {
                    MessageBox.Show($"Checksum4 failed ({temp} != {Checksum4}).", "Error");
                    Environment.Exit(1);
                }

                //Checksum5
                temp = 0;
                for (int i = 0; i < 8; i++) temp += section1[0x4C + (i * 4)];
                if (Checksum5 != temp)
                {
                    MessageBox.Show($"Checksum5 failed ({temp} != {Checksum5}).", "Error");
                    Environment.Exit(1);
                }

                //Checksum6
                temp = 0;
                for (int i = 0; i < 8; i++) temp += section1[0x1C + (i * 4)];
                if (Checksum6 != temp)
                {
                    MessageBox.Show($"Checksum6 failed ({temp} != {Checksum6}).", "Error");
                    Environment.Exit(1);
                }

                //Checksum7
                temp = 0;
                for (int i = 0; i < 14; i++) temp += section1[0x6 + i];
                if (Checksum7 != temp)
                {
                    MessageBox.Show($"Checksum7 failed ({temp} != {Checksum7}).", "Error");
                    Environment.Exit(1);
                }

                Section2Key = new byte[0x20];
                Section2Counter = new byte[0x10];

                if ((section1[0x5] & 4) > 0)
                {
                    Array.Copy(section1, 0x4C, Section2Key, 0, Section2Key.Length);
                    Array.Copy(section1, 0x6C, Section2Counter, 0, Section2Counter.Length);
                }
                else
                {
                    Array.Copy(section1, 0x1C, Section2Key, 0, Section2Key.Length);
                    Array.Copy(section1, 0x3C, Section2Counter, 0, Section2Counter.Length);
                }

                section2 = Utils.AesCtrDecrypt(Section2Key, Section2Counter, section2);

                if (section2[0] != 0x23 || section2[1] != 0x53 || section2[2] != 0x41 || section2[3] != 0x56 || section2[4] != 0x00) //#SAV + 0x00
                {
                    MessageBox.Show("Failed at signature of second section.");
                    Environment.Exit(1);
                }

                //Checksum8
                temp = 0;
                for (int i = 0; i < section2size / 0x20; i++) temp += section2[i * 0x20];
                if (Checksum8 != temp)
                {
                    MessageBox.Show($"Checksum8 failed ({temp} != {Checksum8}).");
                    Environment.Exit(1);
                }

                return section2;
            }
        }

        public void Save(string sPath, byte[] saveFile)
        {
            byte[] Section2Key, Section2Counter;

            //byte[] section2 = File.ReadAllBytes(sPath);
            byte[] section2 = saveFile;
            byte[] section1 = new byte[0x80];
            Utils.GetRandomData(section1, 0x80);
            section1[0x5] = 0x34; // How was this obtained? Why was it specifically put in?

            // For checksum 8
            section1[0x1A] = 0;
            for (int i = 0; i < section2.Length / 0x20; i++) section1[0x1A] += section2[i * 0x20];

            Section2Key = new byte[0x20];
            Section2Counter = new byte[0x10];

            Array.Copy(section1, 0x4C, Section2Key, 0, Section2Key.Length);
            Array.Copy(section1, 0x6C, Section2Counter, 0, Section2Counter.Length);

            section2 = Utils.AesCtrDecrypt(Section2Key, Section2Counter, section2);

            // For checksum 7
            section1[0x15] = 0;
            for (int i = 0; i < 14; i++) section1[0x15] += section1[0x6 + i];

            // For checksum 6
            section1[0x16] = 0;
            for (int i = 0; i < 8; i++) section1[0x16] += section1[0x1C + (i * 4)];

            // For checksum 5
            section1[0x17] = 0;
            for (int i = 0; i < 8; i++) section1[0x17] += section1[0x4C + (i * 4)];

            /// For checksum 4
            section1[0x18] = 0;
            for (int i = 0; i < 4; i++) section1[0x18] += section1[0x3C + i * 4];
            //section1[0x18] = (byte)(section1[0x48] + section1[0x44] + section1[0x3C] + section1[0x40]);

            // For checksum 3
            section1[0x19] = 0;
            for (int i = 0; i < 4; i++) section1[0x19] += section1[0x6C + i * 4];
            //section1[0x19] = (byte)(section1[0x78] + section1[0x74] + section1[0x6C] + section1[0x70]);

            // For checksum 2
            section1[0x1B] = 0;
            for (int i = 0; i < section2.Length / 0x20; i++) section1[0x1B] += section2[i * 0x20];

            // For checksum 1
            section1[0x14] = section1[0x5];
            for (int i = 0; i < 7; i++) section1[0x14] += section1[0x15 + i];

            // #SAV. (File magic number)
            section1[0] = 0x23;
            section1[1] = 0x53;
            section1[2] = 0x41;
            section1[3] = 0x56;
            section1[4] = 0x00;

            byte[] sizeArray = BitConverter.GetBytes(decrypted_size);
            Array.Copy(sizeArray, 0, section1, 0x7c, sizeArray.Length);
            section1 = Utils.AesCtrDecrypt(Section1Key, Section1Counter, section1);

            byte[] completeFile = new byte[encrypted_size];
            Array.Copy(section1, 0, completeFile, 0, section1.Length);
            Array.Copy(section2, 0, completeFile, 0x80, section2.Length);

            //string newPath = sPath.Substring(0, sPath.Length - 8);
            //MessageBox.Show("Encryption success!\n[" + newPath + "_enc.dat]");
            File.WriteAllBytes(sPath, completeFile);
        }
    }
}
