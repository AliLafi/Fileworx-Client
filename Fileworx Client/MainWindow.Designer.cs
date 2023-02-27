using System;

namespace Fileworx_Client
{
    partial class MainWindow
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.previewTab = new System.Windows.Forms.TabPage();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.imageTab = new System.Windows.Forms.TabPage();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.txtCategory = new System.Windows.Forms.ComboBox();
            this.txtCreated = new System.Windows.Forms.DateTimePicker();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.catList = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.previewTab.SuspendLayout();
            this.imageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 305);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(40, 17);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // lblCreated
            // 
            this.lblCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCreated.AutoSize = true;
            this.lblCreated.BackColor = System.Drawing.SystemColors.Control;
            this.lblCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreated.Location = new System.Drawing.Point(15, 334);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(108, 17);
            this.lblCreated.TabIndex = 2;
            this.lblCreated.Text = "Creation Date";
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(15, 363);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(73, 17);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Category";
            this.lblCategory.Visible = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Enabled = false;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(153, 299);
            this.txtTitle.MaxLength = 255;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(730, 23);
            this.txtTitle.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newsToolStripMenuItem,
            this.photoToolStripMenuItem,
            this.userToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // newsToolStripMenuItem
            // 
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.newsToolStripMenuItem.Text = "News";
            this.newsToolStripMenuItem.Click += new System.EventHandler(this.newsToolStripMenuItem_Click);
            // 
            // photoToolStripMenuItem
            // 
            this.photoToolStripMenuItem.Name = "photoToolStripMenuItem";
            this.photoToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.photoToolStripMenuItem.Text = "Photo";
            this.photoToolStripMenuItem.Click += new System.EventHandler(this.photoToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.previewTab);
            this.tabControlMain.Controls.Add(this.imageTab);
            this.tabControlMain.Location = new System.Drawing.Point(18, 393);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(865, 121);
            this.tabControlMain.TabIndex = 8;
            // 
            // previewTab
            // 
            this.previewTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewTab.Controls.Add(this.txtBody);
            this.previewTab.Location = new System.Drawing.Point(4, 22);
            this.previewTab.Name = "previewTab";
            this.previewTab.Padding = new System.Windows.Forms.Padding(3);
            this.previewTab.Size = new System.Drawing.Size(857, 95);
            this.previewTab.TabIndex = 0;
            this.previewTab.Text = "Preview";
            this.previewTab.UseVisualStyleBackColor = true;
            // 
            // txtBody
            // 
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Enabled = false;
            this.txtBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBody.Location = new System.Drawing.Point(3, 3);
            this.txtBody.MaxLength = 10000;
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.Size = new System.Drawing.Size(847, 85);
            this.txtBody.TabIndex = 0;
            this.txtBody.Text = "";
            // 
            // imageTab
            // 
            this.imageTab.Controls.Add(this.pictureBox);
            this.imageTab.Location = new System.Drawing.Point(4, 22);
            this.imageTab.Name = "imageTab";
            this.imageTab.Padding = new System.Windows.Forms.Padding(3);
            this.imageTab.Size = new System.Drawing.Size(857, 95);
            this.imageTab.TabIndex = 1;
            this.imageTab.Text = "Image";
            this.imageTab.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(851, 89);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCategory.Enabled = false;
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Location = new System.Drawing.Point(153, 363);
            this.txtCategory.MaxLength = 255;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(730, 24);
            this.txtCategory.TabIndex = 10;
            this.txtCategory.Visible = false;
            // 
            // txtCreated
            // 
            this.txtCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreated.Enabled = false;
            this.txtCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreated.Location = new System.Drawing.Point(153, 328);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.Size = new System.Drawing.Size(730, 23);
            this.txtCreated.TabIndex = 11;
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Location = new System.Drawing.Point(18, 154);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.Size = new System.Drawing.Size(865, 142);
            this.GridView.TabIndex = 12;
            this.GridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellDoubleClick);
            this.GridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseClick);
            // 
            // searchBar
            // 
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.Location = new System.Drawing.Point(18, 57);
            this.searchBar.MaxLength = 255;
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(641, 26);
            this.searchBar.TabIndex = 13;
            this.searchBar.Text = "Enter Keyword";
            this.searchBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchBar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchBar_MouseClick);
            this.searchBar.Leave += new System.EventHandler(this.searchBar_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(665, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 26);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(777, 59);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(106, 26);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(79, 89);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 20);
            this.startDate.TabIndex = 16;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(79, 128);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 20);
            this.endDate.TabIndex = 17;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(18, 90);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(55, 13);
            this.lblStart.TabIndex = 18;
            this.lblStart.Text = "Start Date";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(18, 128);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(52, 13);
            this.lblEnd.TabIndex = 19;
            this.lblEnd.Text = "End Date";
            // 
            // catList
            // 
            this.catList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.catList.FormattingEnabled = true;
            this.catList.Items.AddRange(new object[] {
            "General",
            "Politics",
            "Sports",
            "Health"});
            this.catList.Location = new System.Drawing.Point(665, 90);
            this.catList.Name = "catList";
            this.catList.Size = new System.Drawing.Size(218, 49);
            this.catList.TabIndex = 20;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 526);
            this.Controls.Add(this.catList);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.GridView);
            this.Controls.Add(this.txtCreated);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Fileworx";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.previewTab.ResumeLayout(false);
            this.imageTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage previewTab;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.TabPage imageTab;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox txtCategory;
        private System.Windows.Forms.DateTimePicker txtCreated;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.CheckedListBox catList;
    }
}

