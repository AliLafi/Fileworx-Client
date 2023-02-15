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
    public class NewsQuery
    {
        SqlDataAdapter _adapter;
        SqlConnection conn;
        string q;
        string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public DataTable ReadAll()
        {
            DataTable dt = new DataTable();

            Run();
            q = $"SELECT * FROM S.T_BUSINESSOBJECT  JOIN S.T_NEWS ON S.T_BUSINESSOBJECT.ID = S.T_NEWS.ID WHERE C_CLASSID=1";
            _adapter = new SqlDataAdapter(q, conn);
            _adapter.Fill(dt);
            conn.Close();

            return dt;
        }

        public void Run()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
            _adapter.Dispose();
        }

    }
}
