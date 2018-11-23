using System;
using System.Windows.Forms;
using DBXV2NSSaveEditor.DecryptEncrypt;
using DBXV2NSSaveEditor.Editor;

namespace DBXV2NSSaveEditor
{
    public partial class Main : Form
    {
        Xv2SavFile save = new Xv2SavFile();
        SaveEditor saveFile;

        public Main()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileNames[0];
                saveFile = new SaveEditor(save.Load(filePath));
                LoadForm();
                saveToolStripMenuItem.Enabled = true;
                checkBoxUnlockSkills.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileNames[0];
                saveFile.SetMoney(Convert.ToUInt32(numericUpDownMoney.Value));
                saveFile.SetTPMedal(Convert.ToUInt32(numericUpDownTPMedal.Value));
                save.Save(filePath, saveFile.GetSaveFile());
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Just a simple save editor for DBXV2 Nintendo Switch\nMade by Ukee from GBATemp");
        }

        private void LoadForm()
        {
            numericUpDownMoney.Value = saveFile.GetMoney();
            numericUpDownMoney.Enabled = true;
            numericUpDownTPMedal.Value = saveFile.GetTPMedal();
            numericUpDownTPMedal.Enabled = true;
        }

        private void checkBoxUnlockSkills_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUnlockSkills.Checked == true)
                saveFile.SkillUnlocker(1);

            if (checkBoxUnlockSkills.Checked == false)
                saveFile.SkillUnlocker(0);
        }
    }
}
