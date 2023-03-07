using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.Objects
{
    public partial class Photo : File
    {

        public override void DBUpdate()
        {

            if (this.ID > -1)
            {
                base.DBUpdate();
                q = $"UPDATE  dbo.T_Photo SET C_location =\'{this.ImagePath}\' WHERE ID = \'{this.ID}\'; ";
                cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();


            }
            else
            {

                base.DBUpdate();
                q = $"INSERT INTO dbo.T_Photo (ID,C_location) VALUES(\'{this.ID}\',\'{this.ImagePath}\')";
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

                    q = $"DELETE FROM dbo.T_Photo WHERE ID =\'{this.ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    base.DBDelete();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                conn.Close();

            }

        }

        public override void DBRead()
        {
            base.DBRead();
            q = $"select * from dbo.T_Photo where ID = \'{this.ID}\'";
            cmd = new SqlCommand(q,conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                this.ImagePath = r["C_location"].ToString();

            }

            conn.Close();
            r.Close();
        }

    }
    
}
