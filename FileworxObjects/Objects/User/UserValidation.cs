using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FileworxObjects.Connection;

namespace FileworxObjects
{
    public partial class User
    {
        public bool Validate()
        {
            bool valid = false;
            conn.Open();
            q = $"Select C_password from dbo.T_Users where C_login_name = \'{this.LoginName}\' ;";
            cmd = new SqlCommand(q, conn);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.Read())
            {
                try
                {

                    string hash = r["C_password"].ToString();
                    valid = BCrypt.Net.BCrypt.Verify(this.Password, hash);
                }
                catch
                {
                    return false;
                }

            }


            conn.Close();
            if (valid)
            {
                return true;
            }
            return false;
        }
    }
}
