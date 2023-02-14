using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fileworx_Client
{
    public partial class MainWindow : Form
    {

        public static string absolutePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\"));
        public static string newsPath = Path.GetFullPath(Path.Combine(absolutePath, @"News"));
        public static string photoPath = Path.GetFullPath(Path.Combine(absolutePath, @"Photos"));
        public static string userPath = Path.GetFullPath(Path.Combine(absolutePath, @"Users"));
        User loggedIn;

        ListViewItem focusedItem;

        static int newsCount = 0;
        static int photoCount = 0;

        public static bool categoryChanged = false;
        public static bool dateChanged = false;

        FileOp fileOp = new FileOp();

        public MainWindow(User u)
        {
            InitializeComponent();
            initPath();
            
            this.WindowState = FormWindowState.Maximized;
            this.loggedIn = u;

            foreach (News.categories cat  in Enum.GetValues(typeof(News.categories)))
                txtCategory.Items.Add(cat.ToString());

            txtCreated.MaxDate = DateTime.Now;
            listView.Select();
            updateTable();

        }


        private void listClick(object sender, MouseEventArgs e)
        {
            
           

    
            var listItem = listView.FocusedItem;
            focusedItem = listItem;
            var row = listItem.Index;

            tabControlMain.TabPages.Remove(imgTab);

            // if right click then delete
            if (e.Button == MouseButtons.Right)
            {

                DialogResult res = MessageBox.Show($"are you sure you want to delete{listItem.Text}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    // if row is less than newsCount than its news object
                    if (row < newsCount)
                    {
                        fileOp.DeleteFile(newsPath + "\\" + listView.FocusedItem.SubItems[5].Text + ".txt");
                        newsCount--;
                    }
                    else
                    {
                        fileOp.DeleteFile(photoPath + "\\" + listView.FocusedItem.SubItems[5].Text + ".txt");
                        photoCount--;
                    }

                    updateTable();


                }

            }

            // if left click show items
            else
            {

                txtTitle.Text = listItem.Text;
                txtCreated.Text = listItem.SubItems[1].Text;
                txtBody.Text = listItem.SubItems[4].Text;

                // if its a photo object also show the image tab
                if (row >= newsCount)
                {
                    tabControlMain.TabPages.Add(imgTab);
                    pictureBox.ImageLocation = listItem.SubItems[3].Text;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    lblCategory.Visible = false;
                    txtCategory.Visible = false;

                }
                else
                {
                    txtCategory.Visible = true;
                    txtCategory.Text = listItem.SubItems[3].Text;
                    lblCategory.Visible = true;
                }

            }

        }

        // double click for editing
        private void double_Click(object sender, MouseEventArgs e)
        {
            var listItem = listView.FocusedItem;
            focusedItem = listItem;
            var row = listItem.Index;

            if (row < newsCount)
            {

                CreateNewsWindow f1 = new CreateNewsWindow(this,focusedItem);
                f1.Show();
            }
            else
            {
                CreatePhotosWindow f1 = new CreatePhotosWindow(this,focusedItem);
                f1.Show();
            }


        }


        public void updateTable()
        {
            newsCount = 0;
            photoCount = 0;
            listView.Items.Clear();

            ListViewItem itemTemp;
            List<List<string>> strTemp;

            Guid guidTemp;
            DateTime dateTemp;

            strTemp = fileOp.ReadFromFile(newsPath);

            foreach (List<string> s in strTemp)
            {
                if (!DateTime.TryParse(s[1], out dateTemp) || !Guid.TryParse(s[5], out guidTemp) || s.Count != 6)
                {
                    continue;
                }


                itemTemp = new ListViewItem(s.ToArray());
                listView.Items.Add(itemTemp);
                newsCount++;
            }

            strTemp = fileOp.ReadFromFile(photoPath);

            foreach (List<string> s in strTemp)
            {
                if (!DateTime.TryParse(s[1], out dateTemp) || !Guid.TryParse(s[5], out guidTemp) || s.Count != 6) continue;
                itemTemp = new ListViewItem(s.ToArray());
                listView.Items.Add(itemTemp);
                photoCount++;
            }

            if (newsCount + photoCount == 0)
            {
                txtTitle.Text = string.Empty;
                txtBody.Text = string.Empty;
                txtCategory.Text = string.Empty;
                txtCreated.Text = string.Empty;
            }

            txtTitle.Modified = false;
            txtBody.Modified = false;
            categoryChanged = false;
            dateChanged = false;

        }

 


  

        // create inital path if there is no path 
        private void initPath()
        {
            if (!Directory.Exists(newsPath))
            {
                Directory.CreateDirectory(newsPath);
            }

            if (!Directory.Exists(photoPath))
            {
                Directory.CreateDirectory(photoPath);
            }

            if (!Directory.Exists(userPath))
            {
                Directory.CreateDirectory(userPath);
            }

        }

  
        // changing window when toolstrip is selected 
        private void newsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewsWindow f1 = new CreateNewsWindow(this,null);
            f1.Show();

        }

        private void photoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePhotosWindow f1 = new CreatePhotosWindow(this,null);
            f1.Show();

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUserWindow f1 = new CreateUserWindow(loggedIn.LoginName);
            f1.Show();

        }

        private void editFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPathWindow f1 = new EditPathWindow(this);
            f1.Show();

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}

