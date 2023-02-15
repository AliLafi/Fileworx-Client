using System;
using System.Collections;
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
    public partial class LoginWindow : Form
    {

        MainWindow main;

        string loggedIn;
        Hashtable Users = new Hashtable();
        public LoginWindow()
        {
            InitializeComponent();
            ReadUsers();
 
           
            
        }

        private void ReadUsers()
        {


            UsersQuery uq = new UsersQuery();
            Users = uq.ReadAll();
           

        }
  
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Users.ContainsKey(txtLogin.Text.Trim()) && Users.ContainsValue(txtPassword.Text))
            {

                MessageBox.Show("Login Successful", "Success");
                loggedIn= txtLogin.Text.Trim();
                main = new MainWindow(loggedIn);
                main.Show();
                this.Hide();
            }

            else
            {

                MessageBox.Show("Login Name or Password is incorrect");
            }
        }
    }
}
