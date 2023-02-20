using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public class User : BusinessObject
    {


        public string LoginName { get; set; }
        public string Password { get; set; }
        public string LastModifier { get; set; }



        public User() { }
        public User(string name, string description, DateTime created, int id, int classid, string loginName, string password, string lastmodifier) : base(name, description, created, id, classid)
        {
            LoginName = loginName;
            Password = password;
            LastModifier = lastmodifier;
        }

        public User(string name, string description, DateTime created, int classid, string loginName, string password, string lastmodifier) : base(name, description, created, classid)
        {
            LoginName = loginName;
            Password = password;
            LastModifier = lastmodifier;

        }

        public override string ToString()
        {
            return $"{Name}%{LoginName}%{Password}%{LastModifier}";
        }

        static SqlConnection conn;
        static string q;
        static readonly string connectionString = "Data Source=ALILAFI;Initial Catalog=Fileworx;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static SqlCommand cmd;

        public override void Update()
        {
            try
            {

                Run();


                if (this.ID > -1)
                {
                    base.Update();
                    q = $"UPDATE  dbo.T_Users SET C_login_name='{this.LoginName}',C_password = \'{this.Password}\',C_last_modifier = \'{this.LastModifier}\' WHERE ID = \'{this.ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    Close();

                }
                else
                {

                    base.Update();

                    q = $"INSERT INTO dbo.T_Users (ID,C_login_name,C_password,C_last_modifier) VALUES(\'{this.ID}\',\'{this.LoginName}\',\'{this.Password}\',\'{this.LastModifier}\')";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
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

        public override void Delete()
        {
            if (this.ID > -1)
            {
                try
                {
                    Run();

                    q = $"DELETE FROM dbo.T_Users WHERE ID =\'{this.ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    base.Delete();
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





        public new static void Run()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public new static void Close()
        {
            conn.Close();
        }



    }

}
