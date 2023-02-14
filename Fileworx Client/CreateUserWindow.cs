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
    public partial class CreateUserWindow : Form
    {

        string modified;
        FileOp fileOp = new FileOp();

        public CreateUserWindow(string modified)
        {
            this.modified= modified;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtLogin.Text == string.Empty || txtPassword.Text == string.Empty)
                MessageBox.Show("All fields must be filled", "Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                User temp = new User(txtName.Text, txtLogin.Text, txtPassword.Text, modified);
                fileOp.WriteToFile(temp, temp.guid.ToString());
                this.Hide();
            }

        }

    }
}
