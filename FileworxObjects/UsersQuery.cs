using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
namespace FileworxObjects
{
    public class UsersQuery
    {
        SqlConnection conn;
        string q;
        SqlCommand cmd;
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public Hashtable ReadAll()
        {
            Hashtable LoginInfo= new Hashtable();
            q = "SELECT C_LOGINNAME,C_PASSWORD from S.T_USERS ";

            try
            {
                Run();
                cmd = new SqlCommand(q, conn);
                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        LoginInfo.Add(sqlDataReader.GetString(0), sqlDataReader.GetString(1));
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                Close();
            }






            return LoginInfo;
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
