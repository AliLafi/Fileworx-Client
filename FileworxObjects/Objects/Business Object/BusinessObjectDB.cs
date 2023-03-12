using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileworxObjects.Connection;

namespace FileworxObjects
{
    public partial class BusinessObject
    {
        public SqlConnection conn = DBConnection.GetSqlConnection();
        public string q;
        public SqlCommand cmd;

        public virtual void DBUpdate()
        {
            CheckConnection();
            try
            {

                if (ID > -1)
                {
                    q = $"UPDATE  dbo.T_BusinessObject SET C_name =\'{Name}\', C_description = \'{Description}\' WHERE C_ID = \'{ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {

                    q = $"INSERT INTO dbo.T_BusinessObject (C_name,C_description,C_creation_date,C_class_id) VALUES(\'{Name}\',\'{Description}\',\'{Created}\',\'{ClassID}\');SELECT SCOPE_IDENTITY()";
                    cmd = new SqlCommand(q, conn);

                    int t = int.Parse(cmd.ExecuteScalar().ToString());
                    ID = t;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CheckConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public virtual void DBDelete()
        {
            if (ID > -1)
            {
                try
                {

                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    q = $"DELETE FROM dbo.T_BusinessObject WHERE C_ID =\'{ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public virtual void DBRead()
        {
            CheckConnection();

            q = $"select * from dbo.T_BusinessObject where C_ID = {ID}";
            cmd = new SqlCommand(q,conn);
            try
            {

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    Created = DateTime.Parse(r["C_Creation_date"].ToString());
                    ClassID = int.Parse(r["C_class_id"].ToString());
                    Description = r["C_description"].ToString();
                    Name = r["C_name"].ToString();

                }
                r.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
