using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public partial class User
    {
        public bool UserExists()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            q = $"select Count(C_login_name) from dbo.T_Users where C_login_name = \'{LoginName}\'";
            cmd = new SqlCommand(q, conn);
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            return count < 1;
        }

        public override void DBUpdate()
        {
            try
            {
                string hashed = BCrypt.Net.BCrypt.HashPassword(Password);

                if (ID > -1)
                {
                    base.DBUpdate();
                    q = $"UPDATE  dbo.T_Users SET C_login_name='{LoginName}',C_password = \'{hashed}\',C_last_modifier = \'{LastModifier}\' WHERE ID = \'{ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    base.DBUpdate();
                    q = $"INSERT INTO dbo.T_Users (ID,C_login_name,C_password,C_last_modifier) VALUES(\'{ID}\',\'{LoginName}\',\'{hashed}\',\'{LastModifier}\')";
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
                conn.Close();
            }
        }

        public override void DBDelete()
        {
            if (ID > -1)
            {
                try
                {
                    q = $"DELETE FROM dbo.T_Users WHERE ID =\'{ID}\'";
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

        public int GetID()
        {
            conn.Open();
            q = $"select ID from dbo.T_Users where C_login_name = \'{LoginName}\'";
            cmd = new SqlCommand(q, conn);
            return int.Parse(cmd.ExecuteScalar().ToString()); ;
        }
    }
}