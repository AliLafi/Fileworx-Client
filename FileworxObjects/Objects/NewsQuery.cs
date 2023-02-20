using FileworxObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public class NewsQuery
    {
        SqlConnection conn;
        string q;
        readonly string connectionString = "Data Source=ALILAFI;Initial Catalog=Fileworx;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<NewsDTO> ReadAllNews()
        {

            Run();
            q = $"SELECT C_ID, C_description, C_name, C_body,C_category, C_creation_date FROM dbo.T_BusinessObject B  INNER JOIN dbo.T_File F  ON B.C_ID = F.ID  Inner Join dbo.T_News N on F.id=N.ID WHERE  C_class_id=1";

            List<NewsDTO> list = new List<NewsDTO>();

            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                NewsDTO dto = new NewsDTO(reader.GetString(2), reader.GetString(1), reader.GetDateTime(5), reader.GetInt32(0), reader.GetString(3), reader.GetString(4));

                list.Add(dto);
            }

            conn.Close();

            return list;
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
