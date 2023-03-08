using System.Data.SqlClient;

namespace FileworxObjects
{
    public partial class User
    {
        public bool Validate()
        {
            bool valid = false;
            conn.Open();
            q = $"Select C_password from dbo.T_Users where C_login_name = \'{LoginName}\' ;";
            cmd = new SqlCommand(q, conn);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.Read())
            {
                try
                {
                    string hash = r["C_password"].ToString();
                    valid = BCrypt.Net.BCrypt.Verify(Password, hash);
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
