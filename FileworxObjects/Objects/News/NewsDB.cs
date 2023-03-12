using System.Data.SqlClient;
using System;

namespace FileworxObjects.Objects
{
    public partial class News
    {
        public override void DBUpdate()
        {
            try
            {

                if (ID > -1)
                {
                    base.DBUpdate();
                    q = $"UPDATE  dbo.T_News SET C_category =\'{Category}\' WHERE ID = \'{ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    base.DBUpdate();
                    q = $"INSERT INTO dbo.T_News (ID,C_CATEGORY) VALUES(\'{ID}\',\'{Category}\')";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public override void DBDelete()
        {
            if (ID > -1)
            {
                try
                {
                    conn.Open();
                    q = $"DELETE FROM dbo.T_News WHERE ID =\'{ID}\'";
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
            q = $"select * from dbo.T_News where ID = {ID}";
            cmd = new SqlCommand(q, conn);
            try
            {

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    Category = r["C_category"].ToString();

                }

                conn.Close();
                r.Close();
            }
            catch(Exception ex )
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
