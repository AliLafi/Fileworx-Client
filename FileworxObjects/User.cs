using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public class User
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string LastModifier { get; set; }
        SqlConnection conn;
        string q;
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;


        SqlCommand cmd;
        public User(string name, string loginName, string password, string lastModifier, int ID)
        {
            Name = name;
            LoginName = loginName;
            Password = password;
            LastModifier = lastModifier;
            this.ID = ID;
        }

        public User(string name, string loginName, string password, string lastModifier)
        {
            Name = name;
            LoginName = loginName;
            Password = password;
            LastModifier = lastModifier;
            ID = -1;
        }

        public override string ToString()
        {
            return $"{Name}%{LoginName}%{Password}%{LastModifier}";
        }


        public void Update()
        {
            
                Run();
                if (this.ID > -1)
                {
                    q = $"UPDATE TABLE S.T_USERS SET C_NAME =\'{this.Name}\', C_LOGINNAME = \'{this.LoginName}\',C_LASTMODIFIED = ADMIN, PASSWORD =\'{this.Password}\' WHERE ID = \'{this.ID}\' ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {

                    q = $"INSERT INTO S.T_USERS (C_NAME,C_LOGINNAME,C_LASTMODIFIED, C_PASSWORD) VALUES(\'{this.Name}\',\'{this.LoginName}\',\'{this.LastModifier}\',\'{this.Password}\')";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
            
        
                Close();

            
        }

        public void Delete()
        {
            if (this.ID > -1)
            {
                try
                {

                    q = $"DELETE FROM S.USERS WHERE ID =\'{this.ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Close();
                }
            }
        }
        public string Read()
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {


                q = $"SELECT * FROM S.T_USERS WHERE ID=\'{this.ID}\'";
                cmd = new SqlCommand(q, conn);
                stringBuilder.Append((string)cmd.ExecuteScalar());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Close();
            }
            return stringBuilder.ToString();
        }

        public void Run()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }



    }

}
