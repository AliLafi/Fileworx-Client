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
    public class Photo : BusinessObject
    {

        public string ImagePath { get; set; }
        SqlConnection conn;
        string q;
        int id;
        SqlCommand cmd;
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public Photo(string title, DateTime created, string description,  string imgPath,string body, int id) : base(title, description, created, body, id)
        {
            ImagePath = imgPath;
        }

        public Photo(string title, DateTime created, string description, string imgPath, string body) : base(title, description, created, body)
        {
            ImagePath = imgPath;
        } 

        public override string ToString()
        {
            return $"{Title}%{Created}%{Description}%{ImagePath}%{Body}";
        }


        public void Update()
        {
            try
            {
                Run();
                if (this.ID > -1)
                {
                    q = $"UPDATE TABLE S.T_BUSINESSOBJECT SET C_TITLE =\'{this.Title}\', C_DESCRIPTION = \'{this.Description}\',C_BODY = \'{this.Body}\' WHERE ID = \'{this.ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    q = $"UPDATE TABLE S.T_PHOTO SET C_LOCATION = \'{this.ImagePath}\' WHERE ID = \'{this.ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {

                    q = $"INSERT INTO S.T_BUSINESSOBJECT (C_TITLE,C_DESCRIPTION,C_CREATIONDATE,C_BODY,C_CLASSID) VALUES(\'{this.Title}\',\'{this.Description}\',\'{this.Created}\',\'{this.Body}\',2);SELECT SCOPE_IDENTITY();";
                    cmd = new SqlCommand(q, conn);

                    id = int.Parse(cmd.ExecuteScalar().ToString());
                    q = $"INSERT INTO S.T_PHOTO (ID,C_LOCATION) VALUES(\'{id}\',\'{this.ImagePath}\')";
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
        public void Delete()
        {
            if (this.ID > -1)
            {
                try
                {
                    Run();
                    q = $"DELETE FROM S.T_PHOTO WHERE ID =\'{this.ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    q = $"DELETE FROM S.T_BUSINESSOBJECT WHERE ID =\'{this.ID}\'";
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

                Run();
                q = $"SELECT * FROM S.T_BUSINESSOBJECT WHERE ID=\'{this.ID}\'";
                cmd = new SqlCommand(q, conn);
                stringBuilder.Append((string)cmd.ExecuteScalar());
                q = $"SELECT C_LOCATION FROM S.T_PHOTO WHERE ID=\'{this.ID}\'";
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
