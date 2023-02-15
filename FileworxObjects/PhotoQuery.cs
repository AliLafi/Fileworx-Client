using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public class PhotoQuery
    {
        SqlDataAdapter _adapter;
        SqlConnection conn;
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        string q;
        public void Run()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        public DataTable ReadAll()
        {
            DataTable dt = new DataTable();

            Run();
            q = $"SELECT * FROM S.T_BUSINESSOBJECT  JOIN S.T_PHOTO ON S.T_BUSINESSOBJECT.ID = S.T_PHOTO.ID WHERE C_CLASSID=2";
            _adapter = new SqlDataAdapter(q, conn);
            _adapter.Fill(dt);
            conn.Close();

            return dt;
        }

        public void Close()
        {
            conn.Close();
        }
    }
}
