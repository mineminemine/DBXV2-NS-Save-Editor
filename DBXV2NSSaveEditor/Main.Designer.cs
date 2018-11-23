namespace DBXV2NSSaveEditor
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelMoney = new System.Windows.Forms.Label();
            this.numericUpDownMoney = new System.Windows.Forms.NumericUpDown();
            this.labelTPMedal = new System.Windows.Forms.Label();
            this.numericUpDownTPMedal = new System.Windows.Forms.NumericUpDown();
            this.checkBoxUnlockSkills = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTPMedal)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "dat";
            this.openFileDialog1.FileName = "savefile1.dat";
            this.openFileDialog1.Filter = "DBXV2 NS save files|*.dat";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "dat";
            this.saveFileDialog1.FileName = "savefile1.dat";
            this.saveFileDialog1.Filter = "DBXV2 NS save files|*.dat";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Location = new System.Drawing.Point(12, 33);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(39, 13);
            this.labelMoney.TabIndex = 4;
            this.labelMoney.Text = "Money";
            // 
            // numericUpDownMoney
            // 
            this.numericUpDownMoney.Enabled = false;
            this.numericUpDownMoney.Location = new System.Drawing.Point(15, 49);
            this.numericUpDownMoney.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownMoney.Name = "numericUpDownMoney";
            this.numericUpDownMoney.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMoney.TabIndex = 5;
            this.numericUpDownMoney.ThousandsSeparator = true;
            // 
            // labelTPMedal
            // 
            this.labelTPMedal.AutoSize = true;
            this.labelTPMedal.Location = new System.Drawing.Point(144, 33);
            this.labelTPMedal.Name = "labelTPMedal";
            this.labelTPMedal.Size = new System.Drawing.Size(53, 13);
            this.labelTPMedal.TabIndex = 6;
            this.labelTPMedal.Text = "TP Medal";
            // 
            // numericUpDownTPMedal
            // 
            this.numericUpDownTPMedal.Enabled = false;
            this.numericUpDownTPMedal.Location = new System.Drawing.Point(147, 49);
            this.numericUpDownTPMedal.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDownTPMedal.Name = "numericUpDownTPMedal";
            this.numericUpDownTPMedal.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTPMedal.TabIndex = 7;
            this.numericUpDownTPMedal.ThousandsSeparator = true;
            // 
            // checkBoxUnlockSkills
            // 
            this.checkBoxUnlockSkills.AutoSize = true;
            this.checkBoxUnlockSkills.Enabled = false;
            this.checkBoxUnlockSkills.Location = new System.Drawing.Point(15, 75);
            this.checkBoxUnlockSkills.Name = "checkBoxUnlockSkills";
            this.checkBoxUnlockSkills.Size = new System.Drawing.Size(101, 17);
            this.checkBoxUnlockSkills.TabIndex = 8;
            this.checkBoxUnlockSkills.Text = "Unlock All Skills";
            this.checkBoxUnlockSkills.UseVisualStyleBackColor = true;
            this.checkBoxUnlockSkills.CheckedChanged += new System.EventHandler(this.checkBoxUnlockSkills_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.checkBoxUnlockSkills);
            this.Controls.Add(this.numericUpDownTPMedal);
            this.Controls.Add(this.labelTPMedal);
            this.Controls.Add(this.numericUpDownMoney);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBXV2 - NS Save Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTPMedal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.NumericUpDown numericUpDownMoney;
        private System.Windows.Forms.Label labelTPMedal;
        private System.Windows.Forms.NumericUpDown numericUpDownTPMedal;
        private System.Windows.Forms.CheckBox checkBoxUnlockSkills;
    }
}