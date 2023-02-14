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

namespace Fileworx_Client
{
    public partial class LoginWindow : Form
    {
        MainWindow main;
        Hashtable Users = new Hashtable();
        Hashtable Guids = new Hashtable();

        FileOp fileOp = new FileOp();
        public static string absolutePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\"));
        public static string userPath = Path.GetFullPath(Path.Combine(absolutePath, @"Users\"));
        User loggedIn;
        public LoginWindow()
        {
            InitializeComponent();
            ReadUsers();
            
        }

        private void ReadUsers()
        {
            Users.Clear();
            List<List<string>> strTemp = fileOp.ReadFromFile(userPath);

            Guid guidTemp;

            foreach (var item in strTemp)
            {
                if (!Guid.TryParse(item[4], out guidTemp) || item.Count != 5)
                {
                    continue;
                }
                
                Users.Add(item[1], item[2]);
                Guids.Add(item[1], guidTemp);
                
            }

        }
        private User ReconstructUser(string guid)
        {
            List<string> temp = fileOp.ReadOneFile(Path.Combine(userPath,guid)+".txt");
            User u = new User(temp[0], temp[1], temp[2], temp[3],new Guid(guid));
            return u;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Users.ContainsKey(txtLogin.Text) && Users.ContainsValue(txtPassword.Text))
            {
                loggedIn = ReconstructUser(Guids[txtLogin.Text].ToString());
                MessageBox.Show("Login Successful","Success");

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
