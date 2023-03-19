using System;
using System.Windows.Forms;
using FileworxObjects.DTOs;

namespace Fileworx_Client
{
    public partial class CreateUserWindow : Form
    {
        readonly MainWindow main;
        readonly ApiRequests req = new ApiRequests();

        public CreateUserWindow(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private bool HasChanged()
        {
            if (txtName.Modified || txtName.Modified || txtPassword.Modified)
            {
                return true;
            }
            return false;
        }

        private bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                return true;
            }
            return false;
        }
        private UserDTO CreateUser()
        {
            return new UserDTO(txtLogin.Text,txtPassword.Text,main.modifier,main.modifier,txtName.Text,"",DateTime.Now,DateTime.Now);
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                if (!IsEmpty())
                {
                    UserDTO temp = CreateUser();
                    string resMessage = await req.Create("user", temp);
                    MessageBox.Show(resMessage);
                    Hide();
                }
                else
                {
                    MessageBox.Show("A field cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private async void BtnCancel_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                if (!IsEmpty())
                {
                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.Yes:

                            UserDTO temp = CreateUser();
                            string resMessage = await req.Create("user", temp);
                            MessageBox.Show(resMessage);
                            Hide();
                            break;

                        case DialogResult.No:

                            Hide();
                            break;
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Not all fields are filled, do you want to exit without change??", "Fields Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        Hide();
                    }
                }
            }
            else
            {
                Hide();
            }
        }

        private async void CreateUserWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasChanged() && Visible == true)
            {
                e.Cancel = true;
                if (!IsEmpty())
                {
                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.No:

                            e.Cancel = false;
                            break;

                        case DialogResult.Yes:

                            UserDTO temp = CreateUser();
                            string resMessage = await req.Create("user", temp);
                            MessageBox.Show(resMessage);
                            e.Cancel = false;
                            break;

                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Not all fields are filled, do you want to exit without change??", "Fields Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        Hide();
                    }
                }
            }
        }
    }
}
