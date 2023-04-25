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
    public partial class PathWindow : Form
    {
        Stream streamToSave;
        string fileName;
        public PathWindow(Stream stream,string name)
        {
            InitializeComponent();
            streamToSave = stream;
            fileName = name;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (streamToSave != null && !string.IsNullOrEmpty(lblPathToSave.Text) ) 
            {
                string path = Path.Combine(lblPathToSave.Text, fileName);
                path += ".docx";
                using (FileStream fileStream =new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    streamToSave.CopyTo(fileStream);
                }
                MessageBox.Show("Saved Successfully");
                Close();
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult res =  folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                lblPathToSave.Text = folderBrowserDialog1.SelectedPath;
                lblPathToSave.Visible= true;
                btnSave.Enabled= true;
            }
        }
    }
}
