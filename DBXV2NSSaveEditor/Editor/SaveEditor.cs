using System;

namespace DBXV2NSSaveEditor.Editor
{
    class SaveEditor
    {
        // Offsets
        readonly int moneyOffset = 0x24; // 4 bytes
        readonly int tpMedalOffset = 0x28; // 4 bytes
        readonly int skillsOffset = 0xB428; // 2760 bytes

        byte[] saveFile = new byte[0xB0780]; // decrypted file size
        int unlockSkills = 0;

        public SaveEditor(byte[] s)
        {
            saveFile = s;
        }

        public uint GetMoney()
        {
            uint money = BitConverter.ToUInt32(saveFile, moneyOffset); // First index
            return money;
        }

        public void SetMoney(uint money)
        {
            byte[] array = BitConverter.GetBytes(money);
            Array.Copy(array, 0, saveFile, moneyOffset, array.Length);
        }

        public uint GetTPMedal()
        {
            uint tpMedal = BitConverter.ToUInt32(saveFile, tpMedalOffset); // First index
            return tpMedal;
        }

        public void SetTPMedal(uint tpMedal)
        {
            byte[] array = BitConverter.GetBytes(tpMedal);
            Array.Copy(array, 0, saveFile, tpMedalOffset, array.Length);
        }

        public void SkillUnlocker(int i)
        {
            if (i == 1)
                unlockSkills = 1;
            else
                unlockSkills = 0;

        }

        public void UnlockAllSkills()
        {
            for (int i = 0; i < 2760; i += 8)
                saveFile[skillsOffset + i] = 1; // 1 for enabled, 0 for disabled
        }

        public byte[] GetSaveFile()
        {
            if (unlockSkills == 1)
                UnlockAllSkills();
            return saveFile;
        }
    }
}
