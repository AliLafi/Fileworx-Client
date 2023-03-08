using System;
using System.Windows.Forms;
using FileworxObjects;
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

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                if (!IsEmpty())
                {
                    UserDTO temp = new UserDTO(txtName.Text, "", DateTime.Now, txtLogin.Text, txtPassword.Text, main.modifier);
                    string x = await req.Create("user", temp);
                    MessageBox.Show(x);
                    main.UpdateTable();
                    Hide();
                }
                else
                {
                    MessageBox.Show("A field cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private async void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                if (!IsEmpty())
                {
                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.Yes:

                            UserDTO temp = new UserDTO(txtName.Text, "", DateTime.Now, txtLogin.Text, txtPassword.Text, main.modifier);
                            await req.Create("user", temp);
                            main.UpdateTable();
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

                            UserDTO temp = new UserDTO(txtName.Text, "", DateTime.Now, txtLogin.Text, txtPassword.Text, main.modifier);
                            await req.Create("user", temp);
                            main.UpdateTable();
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
