using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fileworx_Client
{

    public partial class EditPathWindow : Form
    {
        public static string newsPathTemp = MainWindow.newsPath;
        public static string photoPathTemp = MainWindow.photoPath;
        public static string userPathTemp = MainWindow.userPath;
        MainWindow main;


        public EditPathWindow(MainWindow main)
        {
            InitializeComponent();

            txtNews.Text = newsPathTemp;
            txtPhoto.Text = photoPathTemp;
            txtUser.Text = userPathTemp;
            this.main = main;
        }


        private void btnNews_Click(object sender, EventArgs e)
        {
            DialogResult res = folderDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtNews.Text = folderDialog.SelectedPath;

            }

        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            DialogResult res = folderDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtPhoto.Text = folderDialog.SelectedPath;
            }

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            DialogResult res = folderDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtUser.Text = folderDialog.SelectedPath;
                
            }

        }




        bool FolderExists(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
  
                return true;

            }

            return false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            newsPathTemp = txtNews.Text;
            photoPathTemp = txtPhoto.Text;
            userPathTemp = txtUser.Text;

            if (!(FolderExists(newsPathTemp) && FolderExists(photoPathTemp) && FolderExists(userPathTemp) ) )
            {

                DialogResult res = MessageBox.Show("Not All Paths exist ", "Path Doesn\'t Exist", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (res == DialogResult.Cancel)
                {
                    this.Hide();
                }

            }

            else
            {

                MainWindow.userPath = userPathTemp;
                MainWindow.photoPath = photoPathTemp;
                MainWindow.newsPath = newsPathTemp;

                main.updateTable();
                this.Hide();
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }

}
