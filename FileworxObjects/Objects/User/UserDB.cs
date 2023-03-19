using System;
using System.Data.SqlClient;

namespace FileworxObjects.Objects
{
    public partial class User
    {
        public bool UserExists()
        {
            CheckConnection();

            q = $"select Count(C_login_name) from dbo.T_Users where C_login_name = \'{LoginName}\'";
            cmd = new SqlCommand(q, conn);
            try
            {
                int count = int.Parse(cmd.ExecuteScalar().ToString());
                return count > 0;
            }
            catch (Exception ex)   
            {
                Console.WriteLine(ex.Message);
                return true;
            }

        }

        public override void DBUpdate()
        {
            try
            {
                string hashed = BCrypt.Net.BCrypt.HashPassword(Password);

                if (ID > -1)
                {
                    base.DBUpdate();
                    q = $"UPDATE  dbo.T_Users SET C_login_name='{LoginName}',C_password = \'{hashed}\' WHERE ID = \'{ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    base.DBUpdate();
                    q = $"INSERT INTO dbo.T_Users (ID,C_login_name,C_password) VALUES(\'{ID}\',\'{LoginName}\',\'{hashed}\')";
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
                    CheckConnection();
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
            try
            {

                cmd = new SqlCommand(q, conn);
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}