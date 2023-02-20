using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public class BusinessObject
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int ClassID { get; set; }

        public BusinessObject(string name, string description, DateTime created, int id, int classid)
        {
            Name = name;
            Description = description;
            Created = created;
            this.ID = id;
            ClassID = classid;
        }

        public BusinessObject(string name, string description, DateTime created, int classid)
        {
            Name = name;
            Description = description;
            Created = created;
            this.ID = -1;
            ClassID = classid;
        }
        public BusinessObject() { }


        static SqlConnection conn;
        static string q;
        static SqlCommand cmd;
        static readonly string connectionString = "Data Source=ALILAFI;Initial Catalog=Fileworx;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public virtual void Update()
        {
            try
            {
                Run();

                if (this.ID > -1)
                {
                    q = $"UPDATE  dbo.T_BusinessObject SET C_name =\'{this.Name}\', C_description = \'{this.Description}\' WHERE C_ID = \'{this.ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {

                    q = $"INSERT INTO dbo.T_BusinessObject (C_name,C_description,C_creation_date,C_class_id) VALUES(\'{this.Name}\',\'{this.Description}\',\'{this.Created}\',\'{this.ClassID}\');SELECT SCOPE_IDENTITY()";
                    cmd = new SqlCommand(q, conn);

                    int t = int.Parse(cmd.ExecuteScalar().ToString());
                    this.ID = t;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
        public virtual void Delete()
        {
            if (this.ID > -1)
            {
                try
                {
                    Run();

                    q = $"DELETE FROM dbo.T_BusinessObject WHERE C_ID =\'{this.ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();


                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



            }

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
