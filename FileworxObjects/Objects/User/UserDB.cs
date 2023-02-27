using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
namespace FileworxObjects
{
    public partial class User
    {
        public bool UserExists()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            q = $"select Count(C_login_name) from dbo.T_Users where C_login_name = \'{this.LoginName}\'";
            cmd = new SqlCommand(q,conn);
            int count = int.Parse(cmd.ExecuteScalar().ToString());

            return count <  1;

        }

        public override void DBUpdate()
        {
            try
            {


                string hashed = BCrypt.Net.BCrypt.HashPassword(this.Password);
                
                if (this.ID > -1)
                {
                    base.DBUpdate();
                    q = $"UPDATE  dbo.T_Users SET C_login_name='{this.LoginName}',C_password = \'{hashed}\',C_last_modifier = \'{this.LastModifier}\' WHERE ID = \'{this.ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    
                }
                else
                {
                    
                  

                        base.DBUpdate();
                        q = $"INSERT INTO dbo.T_Users (ID,C_login_name,C_password,C_last_modifier) VALUES(\'{this.ID}\',\'{this.LoginName}\',\'{hashed}\',\'{this.LastModifier}\')";
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
            if (this.ID > -1)
            {
                try
                {


                    q = $"DELETE FROM dbo.T_Users WHERE ID =\'{this.ID}\'";
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
    }
}
