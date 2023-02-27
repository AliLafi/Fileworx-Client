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
        bool valid = false;
        string loggedIn;
        ApiRequests apiRequests= new ApiRequests();
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        public async Task ValidateUser()
        {
            valid = await apiRequests.getLoginInfo(txtLogin.Text,txtPassword.Text);
        }


  
        private async   void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() != string.Empty && txtPassword.Text != string.Empty)
            {
                await ValidateUser();

                if(valid)
                {

                    MessageBox.Show("Login Successful", "Success");
                    loggedIn = txtLogin.Text.Trim();
                    main = new MainWindow(loggedIn);
                    main.Show();
                    this.Hide();

                }
                else
                {

                    MessageBox.Show("Login Name or Password is incorrect");
                }

            }
            else
            {
                MessageBox.Show("Fields cannot be empty");
            }

        }
    }
}
