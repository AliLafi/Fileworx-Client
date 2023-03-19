using System;
using System.Data.SqlClient;

namespace FileworxObjects.Objects
{
    public partial class Photo : File
    {
        public override void DBUpdate()
        {
            try
            {

                if (ID > -1)
                {
                    base.DBUpdate();
                    q = $"UPDATE  dbo.T_Photo SET C_location =\'{ImagePath}\' WHERE ID = \'{ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    base.DBUpdate();
                    q = $"INSERT INTO dbo.T_Photo (ID,C_location) VALUES(\'{ID}\',\'{ImagePath}\')";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void DBDelete()
        {
            if (ID > -1)
            {
                try
                {
                    CheckConnection();
                    q = $"DELETE FROM dbo.T_Photo WHERE ID =\'{ID}\'";
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
            q = $"select * from dbo.T_Photo where ID = \'{ID}\'";
            cmd = new SqlCommand(q,conn);

            try
            {

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    ImagePath = r["C_location"].ToString();
                }

                conn.Close();
                r.Close();
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}
