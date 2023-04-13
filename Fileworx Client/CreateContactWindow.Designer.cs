namespace Fileworx_Client
{
    partial class CreateContactWindow
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblRead = new System.Windows.Forms.Label();
            this.lblWrite = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabTelegram = new System.Windows.Forms.TabControl();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.lblWriteFile = new System.Windows.Forms.Label();
            this.btnWriteFile = new System.Windows.Forms.Button();
            this.checkWriteFile = new System.Windows.Forms.CheckBox();
            this.lblReadFile = new System.Windows.Forms.Label();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.checkReadFile = new System.Windows.Forms.CheckBox();
            this.tabFtp = new System.Windows.Forms.TabPage();
            this.txtWriteFtp = new System.Windows.Forms.TextBox();
            this.txtReadFtp = new System.Windows.Forms.TextBox();
            this.checkWriteFtp = new System.Windows.Forms.CheckBox();
            this.checkReadFtp = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTelegramUsername = new System.Windows.Forms.Label();
            this.txtUsernameTelegram = new System.Windows.Forms.TextBox();
            this.checkWriteTelegram = new System.Windows.Forms.CheckBox();
            this.tabTelegram.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tabFtp.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(13, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 26);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(13, 84);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(121, 26);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(140, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(648, 32);
            this.txtName.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(140, 84);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(648, 32);
            this.txtDescription.TabIndex = 6;
            // 
            // lblRead
            // 
            this.lblRead.AutoSize = true;
            this.lblRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRead.Location = new System.Drawing.Point(135, 173);
            this.lblRead.Name = "lblRead";
            this.lblRead.Size = new System.Drawing.Size(0, 26);
            this.lblRead.TabIndex = 9;
            // 
            // lblWrite
            // 
            this.lblWrite.AutoSize = true;
            this.lblWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWrite.Location = new System.Drawing.Point(135, 272);
            this.lblWrite.Name = "lblWrite";
            this.lblWrite.Size = new System.Drawing.Size(0, 26);
            this.lblWrite.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(686, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 39);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(579, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 39);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tabTelegram
            // 
            this.tabTelegram.Controls.Add(this.tabFile);
            this.tabTelegram.Controls.Add(this.tabFtp);
            this.tabTelegram.Controls.Add(this.tabPage1);
            this.tabTelegram.Location = new System.Drawing.Point(13, 122);
            this.tabTelegram.Name = "tabTelegram";
            this.tabTelegram.SelectedIndex = 0;
            this.tabTelegram.Size = new System.Drawing.Size(775, 256);
            this.tabTelegram.TabIndex = 14;
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.lblWriteFile);
            this.tabFile.Controls.Add(this.btnWriteFile);
            this.tabFile.Controls.Add(this.checkWriteFile);
            this.tabFile.Controls.Add(this.lblReadFile);
            this.tabFile.Controls.Add(this.btnReadFile);
            this.tabFile.Controls.Add(this.checkReadFile);
            this.tabFile.Location = new System.Drawing.Point(4, 22);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(767, 230);
            this.tabFile.TabIndex = 0;
            this.tabFile.Text = "File";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // lblWriteFile
            // 
            this.lblWriteFile.AutoSize = true;
            this.lblWriteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWriteFile.Location = new System.Drawing.Point(142, 167);
            this.lblWriteFile.Name = "lblWriteFile";
            this.lblWriteFile.Size = new System.Drawing.Size(0, 20);
            this.lblWriteFile.TabIndex = 5;
            // 
            // btnWriteFile
            // 
            this.btnWriteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteFile.Location = new System.Drawing.Point(7, 167);
            this.btnWriteFile.Name = "btnWriteFile";
            this.btnWriteFile.Size = new System.Drawing.Size(81, 27);
            this.btnWriteFile.TabIndex = 4;
            this.btnWriteFile.Text = "Browse";
            this.btnWriteFile.UseVisualStyleBackColor = true;
            this.btnWriteFile.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // checkWriteFile
            // 
            this.checkWriteFile.AutoSize = true;
            this.checkWriteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkWriteFile.Location = new System.Drawing.Point(7, 137);
            this.checkWriteFile.Name = "checkWriteFile";
            this.checkWriteFile.Size = new System.Drawing.Size(121, 24);
            this.checkWriteFile.TabIndex = 3;
            this.checkWriteFile.Text = "Transmission";
            this.checkWriteFile.UseVisualStyleBackColor = true;
            this.checkWriteFile.CheckedChanged += new System.EventHandler(this.CheckWriteFile_CheckedChanged);
            // 
            // lblReadFile
            // 
            this.lblReadFile.AutoSize = true;
            this.lblReadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadFile.Location = new System.Drawing.Point(142, 64);
            this.lblReadFile.Name = "lblReadFile";
            this.lblReadFile.Size = new System.Drawing.Size(0, 20);
            this.lblReadFile.TabIndex = 2;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadFile.Location = new System.Drawing.Point(7, 59);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(81, 31);
            this.btnReadFile.TabIndex = 1;
            this.btnReadFile.Text = "Browse";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // checkReadFile
            // 
            this.checkReadFile.AutoSize = true;
            this.checkReadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkReadFile.Location = new System.Drawing.Point(7, 29);
            this.checkReadFile.Name = "checkReadFile";
            this.checkReadFile.Size = new System.Drawing.Size(101, 24);
            this.checkReadFile.TabIndex = 0;
            this.checkReadFile.Text = "Reception";
            this.checkReadFile.UseVisualStyleBackColor = true;
            this.checkReadFile.CheckedChanged += new System.EventHandler(this.CheckReadFile_CheckedChanged);
            // 
            // tabFtp
            // 
            this.tabFtp.Controls.Add(this.txtWriteFtp);
            this.tabFtp.Controls.Add(this.txtReadFtp);
            this.tabFtp.Controls.Add(this.checkWriteFtp);
            this.tabFtp.Controls.Add(this.checkReadFtp);
            this.tabFtp.Controls.Add(this.lblPassword);
            this.tabFtp.Controls.Add(this.lblUsername);
            this.tabFtp.Controls.Add(this.lblHost);
            this.tabFtp.Controls.Add(this.txtPassword);
            this.tabFtp.Controls.Add(this.txtUsername);
            this.tabFtp.Controls.Add(this.txtHost);
            this.tabFtp.Location = new System.Drawing.Point(4, 22);
            this.tabFtp.Name = "tabFtp";
            this.tabFtp.Padding = new System.Windows.Forms.Padding(3);
            this.tabFtp.Size = new System.Drawing.Size(767, 230);
            this.tabFtp.TabIndex = 1;
            this.tabFtp.Text = "Ftp";
            this.tabFtp.UseVisualStyleBackColor = true;
            // 
            // txtWriteFtp
            // 
            this.txtWriteFtp.Enabled = false;
            this.txtWriteFtp.Location = new System.Drawing.Point(138, 179);
            this.txtWriteFtp.Name = "txtWriteFtp";
            this.txtWriteFtp.Size = new System.Drawing.Size(623, 20);
            this.txtWriteFtp.TabIndex = 9;
            // 
            // txtReadFtp
            // 
            this.txtReadFtp.Enabled = false;
            this.txtReadFtp.Location = new System.Drawing.Point(138, 131);
            this.txtReadFtp.Name = "txtReadFtp";
            this.txtReadFtp.Size = new System.Drawing.Size(623, 20);
            this.txtReadFtp.TabIndex = 8;
            // 
            // checkWriteFtp
            // 
            this.checkWriteFtp.AutoSize = true;
            this.checkWriteFtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkWriteFtp.Location = new System.Drawing.Point(11, 176);
            this.checkWriteFtp.Name = "checkWriteFtp";
            this.checkWriteFtp.Size = new System.Drawing.Size(121, 24);
            this.checkWriteFtp.TabIndex = 7;
            this.checkWriteFtp.Text = "Transmission";
            this.checkWriteFtp.UseVisualStyleBackColor = true;
            this.checkWriteFtp.CheckedChanged += new System.EventHandler(this.CheckWriteFtp_CheckedChanged);
            // 
            // checkReadFtp
            // 
            this.checkReadFtp.AutoSize = true;
            this.checkReadFtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkReadFtp.Location = new System.Drawing.Point(11, 131);
            this.checkReadFtp.Name = "checkReadFtp";
            this.checkReadFtp.Size = new System.Drawing.Size(105, 24);
            this.checkReadFtp.TabIndex = 6;
            this.checkReadFtp.Text = "Reception ";
            this.checkReadFtp.UseVisualStyleBackColor = true;
            this.checkReadFtp.CheckedChanged += new System.EventHandler(this.CheckReadFtp_CheckedChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(7, 94);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(7, 57);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 20);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.Location = new System.Drawing.Point(7, 20);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(43, 20);
            this.lblHost.TabIndex = 3;
            this.lblHost.Text = "Host";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(138, 94);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(623, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(138, 57);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(626, 21);
            this.txtUsername.TabIndex = 1;
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHost.Location = new System.Drawing.Point(138, 20);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(623, 21);
            this.txtHost.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTelegramUsername);
            this.tabPage1.Controls.Add(this.txtUsernameTelegram);
            this.tabPage1.Controls.Add(this.checkWriteTelegram);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 230);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Telegram";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTelegramUsername
            // 
            this.lblTelegramUsername.AutoSize = true;
            this.lblTelegramUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelegramUsername.Location = new System.Drawing.Point(6, 75);
            this.lblTelegramUsername.Name = "lblTelegramUsername";
            this.lblTelegramUsername.Size = new System.Drawing.Size(170, 20);
            this.lblTelegramUsername.TabIndex = 2;
            this.lblTelegramUsername.Text = "Telegram Username";
            // 
            // txtUsernameTelegram
            // 
            this.txtUsernameTelegram.Enabled = false;
            this.txtUsernameTelegram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameTelegram.Location = new System.Drawing.Point(186, 69);
            this.txtUsernameTelegram.Name = "txtUsernameTelegram";
            this.txtUsernameTelegram.Size = new System.Drawing.Size(575, 26);
            this.txtUsernameTelegram.TabIndex = 1;
            // 
            // checkWriteTelegram
            // 
            this.checkWriteTelegram.AutoSize = true;
            this.checkWriteTelegram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkWriteTelegram.Location = new System.Drawing.Point(6, 19);
            this.checkWriteTelegram.Name = "checkWriteTelegram";
            this.checkWriteTelegram.Size = new System.Drawing.Size(138, 24);
            this.checkWriteTelegram.TabIndex = 0;
            this.checkWriteTelegram.Text = "Transmission ";
            this.checkWriteTelegram.UseVisualStyleBackColor = true;
            this.checkWriteTelegram.CheckedChanged += new System.EventHandler(this.CheckWriteTelegram_CheckedChanged);
            // 
            // CreateContactWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabTelegram);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblWrite);
            this.Controls.Add(this.lblRead);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Name = "CreateContactWindow";
            this.Text = "CreateContact";
            this.tabTelegram.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            this.tabFtp.ResumeLayout(false);
            this.tabFtp.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblRead;
        private System.Windows.Forms.Label lblWrite;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabTelegram;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.TabPage tabFtp;
        private System.Windows.Forms.Label lblWriteFile;
        private System.Windows.Forms.Button btnWriteFile;
        private System.Windows.Forms.CheckBox checkWriteFile;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.CheckBox checkReadFile;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblReadFile;
        private System.Windows.Forms.TextBox txtWriteFtp;
        private System.Windows.Forms.TextBox txtReadFtp;
        private System.Windows.Forms.CheckBox checkWriteFtp;
        private System.Windows.Forms.CheckBox checkReadFtp;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblTelegramUsername;
        private System.Windows.Forms.TextBox txtUsernameTelegram;
        private System.Windows.Forms.CheckBox checkWriteTelegram;
    }
}