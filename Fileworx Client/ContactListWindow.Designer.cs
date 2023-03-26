namespace Fileworx_Client
{
    partial class ContactListWindow
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
            this.GridView = new System.Windows.Forms.DataGridView();
            this.checkRead = new System.Windows.Forms.CheckBox();
            this.checkWrite = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Location = new System.Drawing.Point(12, 159);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.Size = new System.Drawing.Size(776, 279);
            this.GridView.TabIndex = 0;
            this.GridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellDoubleClick);
            this.GridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseClickAsync);
            // 
            // checkRead
            // 
            this.checkRead.AutoSize = true;
            this.checkRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkRead.Location = new System.Drawing.Point(13, 23);
            this.checkRead.Name = "checkRead";
            this.checkRead.Size = new System.Drawing.Size(202, 30);
            this.checkRead.TabIndex = 1;
            this.checkRead.Text = "Recieve Contacts";
            this.checkRead.UseVisualStyleBackColor = true;
            this.checkRead.CheckedChanged += new System.EventHandler(this.CheckRead_CheckedChanged);
            // 
            // checkWrite
            // 
            this.checkWrite.AutoSize = true;
            this.checkWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkWrite.Location = new System.Drawing.Point(12, 59);
            this.checkWrite.Name = "checkWrite";
            this.checkWrite.Size = new System.Drawing.Size(252, 30);
            this.checkWrite.TabIndex = 2;
            this.checkWrite.Text = "Transmission Contacts";
            this.checkWrite.UseVisualStyleBackColor = true;
            this.checkWrite.CheckedChanged += new System.EventHandler(this.CheckWrite_CheckedChangedAsync);
            // 
            // ContactListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkWrite);
            this.Controls.Add(this.checkRead);
            this.Controls.Add(this.GridView);
            this.Name = "ContactListWindow";
            this.Text = "ContactListWindow";
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.CheckBox checkRead;
        private System.Windows.Forms.CheckBox checkWrite;
    }
}