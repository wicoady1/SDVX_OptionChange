namespace SDVX_OptionChange
{
    partial class frmSDVXOption
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPremFreeHelp = new System.Windows.Forms.Button();
            this.chkPremFree = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNavigator = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkStageSafe = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEventMode = new System.Windows.Forms.CheckBox();
            this.chkDiffUnlock = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDiffUnlock);
            this.groupBox1.Controls.Add(this.chkEventMode);
            this.groupBox1.Controls.Add(this.btnPremFreeHelp);
            this.groupBox1.Controls.Add(this.chkPremFree);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbNavigator);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.chkStageSafe);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 245);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SDVX DLL";
            // 
            // btnPremFreeHelp
            // 
            this.btnPremFreeHelp.Location = new System.Drawing.Point(176, 96);
            this.btnPremFreeHelp.Name = "btnPremFreeHelp";
            this.btnPremFreeHelp.Size = new System.Drawing.Size(17, 23);
            this.btnPremFreeHelp.TabIndex = 5;
            this.btnPremFreeHelp.Text = "?";
            this.btnPremFreeHelp.UseVisualStyleBackColor = true;
            this.btnPremFreeHelp.Click += new System.EventHandler(this.btnPremFreeHelp_Click);
            // 
            // chkPremFree
            // 
            this.chkPremFree.AutoSize = true;
            this.chkPremFree.Location = new System.Drawing.Point(40, 100);
            this.chkPremFree.Name = "chkPremFree";
            this.chkPremFree.Size = new System.Drawing.Size(130, 17);
            this.chkPremFree.TabIndex = 4;
            this.chkPremFree.Text = "\"Premium Free\" Mode";
            this.chkPremFree.UseVisualStyleBackColor = true;
            this.chkPremFree.CheckedChanged += new System.EventHandler(this.chkPremFree_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Navigator:";
            // 
            // cmbNavigator
            // 
            this.cmbNavigator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNavigator.FormattingEnabled = true;
            this.cmbNavigator.Location = new System.Drawing.Point(40, 169);
            this.cmbNavigator.Name = "cmbNavigator";
            this.cmbNavigator.Size = new System.Drawing.Size(235, 21);
            this.cmbNavigator.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(6, 216);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(301, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply!";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkStageSafe
            // 
            this.chkStageSafe.AutoSize = true;
            this.chkStageSafe.Location = new System.Drawing.Point(40, 54);
            this.chkStageSafe.Name = "chkStageSafe";
            this.chkStageSafe.Size = new System.Drawing.Size(93, 17);
            this.chkStageSafe.TabIndex = 0;
            this.chkStageSafe.Text = "All Stage Safe";
            this.chkStageSafe.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "credit to SOWS for Modification Info";
            // 
            // chkEventMode
            // 
            this.chkEventMode.AutoSize = true;
            this.chkEventMode.Location = new System.Drawing.Point(40, 31);
            this.chkEventMode.Name = "chkEventMode";
            this.chkEventMode.Size = new System.Drawing.Size(114, 17);
            this.chkEventMode.TabIndex = 6;
            this.chkEventMode.Text = "Force Event Mode";
            this.chkEventMode.UseVisualStyleBackColor = true;
            // 
            // chkDiffUnlock
            // 
            this.chkDiffUnlock.AutoSize = true;
            this.chkDiffUnlock.Location = new System.Drawing.Point(40, 77);
            this.chkDiffUnlock.Name = "chkDiffUnlock";
            this.chkDiffUnlock.Size = new System.Drawing.Size(117, 17);
            this.chkDiffUnlock.TabIndex = 7;
            this.chkDiffUnlock.Text = "All Difficulty Unlock";
            this.chkDiffUnlock.UseVisualStyleBackColor = true;
            // 
            // frmSDVXOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 421);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSDVXOption";
            this.Text = "SDVX HDD Hack by mirael";
            this.Load += new System.EventHandler(this.frmSDVXOption_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNavigator;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkStageSafe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPremFreeHelp;
        private System.Windows.Forms.CheckBox chkPremFree;
        private System.Windows.Forms.CheckBox chkEventMode;
        private System.Windows.Forms.CheckBox chkDiffUnlock;
    }
}

