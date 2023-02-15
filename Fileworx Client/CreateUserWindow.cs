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
using FileworxObjects;

namespace Fileworx_Client
{
    public partial class CreateUserWindow : Form
    {

        MainWindow main;
        User userItem;
        string LastMod;
        public CreateUserWindow(MainWindow m ,string mod, User u=null)
        {
            
            InitializeComponent();
            this.main = m;
            LastMod= mod;
            if(u != null)
            {
                this.userItem= u;
                //FillTxt();
            }
        }

        private bool hasChanged()
        {
            if (txtName.Modified || txtName.Modified  || txtPassword.Modified)
            {

                return true;

            }

            return false;

        }
        private bool isEmpty()
        {
            if (txtName.Text == string.Empty || txtLogin.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                return true;
            }
            return false;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                if (!isEmpty())
                {
                    if (userItem == null)
                    {
 
                        User temp = new User(txtName.Text,txtLogin.Text,txtPassword.Text,LastMod);
                        temp.Update();
                    }
                    else
                    {

                        //userItem.Update();
                    }

                    main.updateTable();
                    this.Hide();

                }

                else
                {
                    MessageBox.Show("A field cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (hasChanged())
            {
                if (!isEmpty())
                {
                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.Yes:

                            if (userItem == null)
                            {
                                User temp = new User(txtName.Text, txtLogin.Text, txtPassword.Text, LastMod);
                                temp.Update(); temp.Update();
                            }
                            else
                            {
                                //userItem.Update();

                            }
                            main.updateTable();
                            this.Hide();

                            break;

                        case DialogResult.No:

                            this.Hide();
                            break;

                    }

                }

                else
                {
                    DialogResult res = MessageBox.Show("Not all fields are filled, do you want to exit without change??", "Fields Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        this.Hide();
                    }

                }
            }
            else
            {
                this.Hide();
            }
        }

        private void CreateUserWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasChanged() && this.Visible == true)
            {
                e.Cancel = true;
                if (!isEmpty())
                {

                    DialogResult res = MessageBox.Show("Do you want to save the edit?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {

                        case DialogResult.No:

                            e.Cancel = false;
                            break;

                        case DialogResult.Yes:
                            if (userItem == null)
                            {
                                User temp = new User(txtName.Text, txtLogin.Text, txtPassword.Text, LastMod);
                                temp.Update();
                            }
                            else
                            {
                                //userItem.Update()

                            }

                            main.updateTable();
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
                        this.Hide();
                    }

                }

            }

        }

    }

}
