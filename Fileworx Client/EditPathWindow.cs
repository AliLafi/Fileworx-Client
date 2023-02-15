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

        MainWindow main;


        public EditPathWindow(MainWindow main)
        {
            InitializeComponent();


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
           

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }

}
