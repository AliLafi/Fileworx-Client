using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public class News : File
    {



        public string Category { get; set; }


        public News(string name, string description, DateTime created, int id, string body, string category) : base(name, description, created, id, body, 1)
        {
            Category = category;
        }

        public News(string name, string description, DateTime created, string body, string category) : base(name, description, created, body, 1)
        {
            Category = category;
        }
        public News() { }

        public override string ToString()
        {
            return $"{Name}%{Created}%{Description}%{Category}%{Body}";
        }




        static SqlConnection conn;
        static string q;
        static SqlCommand cmd;
        static readonly string connectionString = "Data Source=ALILAFI;Initial Catalog=Fileworx;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public override void Update()
        {
            try
            {

                Run();

                if (this.ID > -1)
                {
                    base.Update();
                    q = $"UPDATE  dbo.T_News SET C_category =\'{this.Category}\' WHERE ID = \'{this.ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    Close();

                }
                else
                {

                    base.Update();
                    q = $"INSERT INTO dbo.T_News (ID,C_CATEGORY) VALUES(\'{this.ID}\',\'{this.Category}\')";
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


        public new void Run()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public new void Close()
        {
            conn.Close();

        }


        public override void Delete()
        {
            if (this.ID > -1)
            {
                try
                {
                    Run();

                    q = $"DELETE FROM dbo.T_News WHERE ID =\'{this.ID}\'";
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


    }

}
