using System;
using System.Security.Cryptography;

namespace DBXV2NSSaveEditor
{
    public static class Utils
    {

        public static byte[] AesCtrDecrypt(byte[] key, byte[] counter, byte[] data)
        {
            int KEY_SIZE = key.Length * 8;
            int BLOCK_SIZE = counter.Length;

            byte[] result = new byte[data.Length];
            data.CopyTo(result, 0);
            byte[] encBlock = new byte[BLOCK_SIZE];
            int blocklength = data.Length / BLOCK_SIZE;
            if (data.Length % BLOCK_SIZE > 0) blocklength++;

            byte[] block = new byte[counter.Length];
            counter.CopyTo(block, 0);

            //set index start to counter
            long index = SwapEndian(BitConverter.ToInt64(counter, BLOCK_SIZE - 8));

            RijndaelManaged rm = new RijndaelManaged
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.None,
                KeySize = KEY_SIZE,
                BlockSize = BLOCK_SIZE * 8,
                Key = key,
                IV = new byte[BLOCK_SIZE]
            };

            using (var ict = rm.CreateEncryptor())
            {
                for (long i = 0; i < blocklength; i++)
                {
                    //generate counter from index
                    Array.Copy(BitConverter.GetBytes(index), 0, block, BLOCK_SIZE - 8, 8);
                    Array.Reverse(block, BLOCK_SIZE - 8, 8); //big endian

                    //encrypt counter
                    ict.TransformBlock(block, 0, BLOCK_SIZE, encBlock, 0);

                    //de/encrypt data
                    Xor(result, (int)(i * BLOCK_SIZE), encBlock);

                    index++;
                }
            }
            rm.Clear();
            return result;
        }
        
        public static void GetRandomData(byte[] buf, uint len)
        {
            IntPtr hProv = new IntPtr();

            if (!Advapi32.CryptAcquireContext(ref hProv, null, null, Advapi32.PROV_RSA_FULL, Advapi32.CRYPT_VERIFYCONTEXT))
            {
                Console.WriteLine("CryptAquireContext error");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            if (!Advapi32.CryptGenRandom(hProv, len, buf))
            {
                Console.WriteLine("CryptGenRandom error");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Advapi32.CryptReleaseContext(hProv, 0);
        }

        public static void Xor(byte[] data, int offset, byte[] xorkey)
        {
            for (int i = 0; i < xorkey.Length; i++)
            {
                if (i + offset >= data.Length) break;
                data[i + offset] ^= xorkey[i];
            }
        }

        public static short SwapEndian(short value)
        {
            byte[] tmp = BitConverter.GetBytes(value);

            short result = 0;

            result += (short)(tmp[0] << 8);
            result += tmp[1];

            return result;
        }

        public static ushort SwapEndian(ushort value)
        {
            byte[] tmp = BitConverter.GetBytes(value);

            ushort result = 0;

            result += (ushort)(tmp[0] << 8);
            result += tmp[1];

            return result;
        }

        public static int SwapEndian(int value)
        {
            byte[] tmp = BitConverter.GetBytes(value);

            int result = 0;

            result += tmp[0] << 24;
            result += tmp[1] << 16;
            result += tmp[2] << 8;
            result += tmp[3];

            return result;
        }

        public static uint SwapEndian(uint value)
        {
            byte[] tmp = BitConverter.GetBytes(value);

            uint result = 0;

            result += (uint)(tmp[0] << 24);
            result += (uint)(tmp[1] << 16);
            result += (uint)(tmp[2] << 8);
            result += tmp[3];

            return result;
        }

        public static long SwapEndian(long value)
        {
            byte[] tmp = BitConverter.GetBytes(value);

            long result = 0;

            result += ((long)tmp[0] << 56);
            result += ((long)tmp[1] << 48);
            result += ((long)tmp[2] << 40);
            result += ((long)tmp[3] << 32);
            result += ((long)tmp[4] << 24);
            result += ((long)tmp[5] << 16);
            result += ((long)tmp[6] << 8);
            result += tmp[7];

            return result;
        }

        public static ulong SwapEndian(ulong value)
        {
            byte[] tmp = BitConverter.GetBytes(value);

            ulong result = 0;

            result += ((ulong)tmp[0] << 56);
            result += ((ulong)tmp[1] << 48);
            result += ((ulong)tmp[2] << 40);
            result += ((ulong)tmp[3] << 32);
            result += ((ulong)tmp[4] << 24);
            result += ((ulong)tmp[5] << 16);
            result += ((ulong)tmp[6] << 8);
            result += tmp[7];

            return result;
        }

    }
}
