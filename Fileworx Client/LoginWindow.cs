﻿using FileworxObjects;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fileworx_Client
{
    public partial class LoginWindow : Form
    {
        MainWindow main;
        readonly ApiRequests apiRequests= new ApiRequests();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtPassword.Text)))
            {
                await CheckLoginCredentials();
            }
            else
            {
                MessageBox.Show("Fields cannot be empty");
            }
        }

        private async Task CheckLoginCredentials()
        {
            int id = await apiRequests.GetLoginInfo(txtLogin.Text, txtPassword.Text);
            if (id != -1)
            {
                MessageBox.Show("Login Successful", "Success");
                main = new MainWindow(id);
                main.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Login Name or Password is incorrect");
            }
        }
    }
}
