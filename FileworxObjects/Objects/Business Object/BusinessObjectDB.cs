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
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }


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


        public virtual void DBDelete()
        {
            if (this.ID > -1)
            {
                try
                {

                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
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

        public virtual void DBRead()
        {

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            q = $"select * from dbo.T_BusinessObject where C_ID = {this.ID}";
            cmd = new SqlCommand(q);
            
            SqlDataReader r = cmd.ExecuteReader();
        
            while (r.Read())
            {
                this.Created = DateTime.Parse(r["C_Creation_date"].ToString());
                this.ClassID = int.Parse(r["C_class_id"].ToString());
                this.Description = r["C_description"].ToString();
                this.Name = r["Name"].ToString();

        
            }
        
        }

    }

}
