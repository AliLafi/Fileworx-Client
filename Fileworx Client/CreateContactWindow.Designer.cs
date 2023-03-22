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
            this.checkRead = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.checkWrite = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.lblRead = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblWrite = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            // checkRead
            // 
            this.checkRead.AutoSize = true;
            this.checkRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRead.Location = new System.Drawing.Point(18, 137);
            this.checkRead.Name = "checkRead";
            this.checkRead.Size = new System.Drawing.Size(83, 30);
            this.checkRead.TabIndex = 3;
            this.checkRead.Text = "Read";
            this.checkRead.UseVisualStyleBackColor = true;
            this.checkRead.CheckedChanged += new System.EventHandler(this.CheckRead_CheckedChanged);
            // 
            // checkWrite
            // 
            this.checkWrite.AutoSize = true;
            this.checkWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkWrite.Location = new System.Drawing.Point(19, 236);
            this.checkWrite.Name = "checkWrite";
            this.checkWrite.Size = new System.Drawing.Size(82, 30);
            this.checkWrite.TabIndex = 4;
            this.checkWrite.Text = "Write";
            this.checkWrite.UseVisualStyleBackColor = true;
            this.checkWrite.CheckedChanged += new System.EventHandler(this.CheckWrite_CheckedChanged);
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
            // btnWrite
            // 
            this.btnWrite.Enabled = false;
            this.btnWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWrite.Location = new System.Drawing.Point(18, 272);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(82, 33);
            this.btnWrite.TabIndex = 8;
            this.btnWrite.Text = "Browse";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
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
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(19, 173);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(82, 33);
            this.btnRead.TabIndex = 10;
            this.btnRead.Text = "Browse";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
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
            // CreateContactWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblWrite);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.lblRead);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.checkWrite);
            this.Controls.Add(this.checkRead);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Name = "CreateContactWindow";
            this.Text = "CreateContact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox checkRead;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox checkWrite;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label lblRead;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblWrite;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}