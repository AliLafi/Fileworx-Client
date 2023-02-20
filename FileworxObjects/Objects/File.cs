using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileworxObjects
{
    public class File : BusinessObject
    {
        public string Body { get; set; }

        public File(string name, string description, DateTime created, int id, string body, int classid) : base(name, description, created, id, classid)
        {
            Body = body;
        }

        public File(string name, string description, DateTime created, string body, int classid) : base(name, description, created, classid)
        {
            Body = body;
        }

        public File() { }

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
                    q = $"UPDATE  dbo.T_File SET C_body =\'{this.Body}\' WHERE ID = \'{this.ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    base.Update();

                    q = $"INSERT INTO dbo.T_File (C_body,ID) VALUES(\'{this.Body}\',\'{this.ID}\');";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public override void Delete()
        {
            if (this.ID > -1)
            {
                try
                {
                    Run();

                    q = $"DELETE FROM dbo.T_File WHERE ID =\'{this.ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    base.Delete();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



            }

        }
        public new void Run()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }



    }
}
