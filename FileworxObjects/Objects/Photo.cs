using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public class Photo : File
    {

        public string ImagePath { get; set; }

        public Photo(string name, string description, DateTime created, int id, string body, string imagepath, int classid) : base(name, description, created, id, body, classid)
        {
            ImagePath = imagepath;
        }

        public Photo(string name, string description, DateTime created, string body, string imgPath, int classid) : base(name, description, created, body, classid)
        {
            ImagePath = imgPath;
        }

        public Photo() { }

        public override string ToString()
        {
            return $"{Name}%{Created}%{Description}%{ImagePath}%{Body}";
        }

        static SqlConnection conn;
        static string q;
        static SqlCommand cmd;
        static readonly string connectionString = "Data Source=ALILAFI;Initial Catalog=Fileworx;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void UpdatePhoto()
        {
            try
            {

                Run();


                if (this.ID > -1)
                {
                    base.Update();
                    q = $"UPDATE  dbo.T_Photo SET C_location =\'{this.ImagePath}\' WHERE ID = \'{this.ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    Close();

                }
                else
                {

                    base.Update();
                    q = $"INSERT INTO dbo.T_Photo (ID,C_location) VALUES(\'{this.ID}\',\'{this.ImagePath}\')";
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

                    q = $"DELETE FROM dbo.T_Photo WHERE ID =\'{this.ID}\'";
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
