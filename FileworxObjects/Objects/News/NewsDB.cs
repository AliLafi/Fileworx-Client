
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileworxObjects.Connection;
using System;
namespace FileworxObjects.Objects
{
    public partial class News
    {

        public override void DBUpdate()
        {

            if (this.ID > -1)
            {
                base.DBUpdate();
                q = $"UPDATE  dbo.T_News SET C_category =\'{this.Category}\' WHERE ID = \'{this.ID}\'; ";
                cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();

            }
            else
            {

                base.DBUpdate();
                q = $"INSERT INTO dbo.T_News (ID,C_CATEGORY) VALUES(\'{this.ID}\',\'{this.Category}\')";
                cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public override void DBDelete()
        {
            if (this.ID > -1)
            {
                try
                {
                    conn.Open();

                    q = $"DELETE FROM dbo.T_News WHERE ID =\'{this.ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    base.DBDelete();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    conn.Close();
                }

            }

        }

        public override void DBRead()
        {
            base.DBRead();
            q = $"select * from dbo.T_News where ID = {this.ID}";
            cmd = new SqlCommand(q);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                this.Category = r["C_category"].ToString();

            }

            conn.Close();

        }

    }

}
