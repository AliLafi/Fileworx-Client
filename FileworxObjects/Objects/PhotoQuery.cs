using FileworxObjects.DTOs;
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
        SqlConnection conn;
        readonly string connectionString = "Data Source=ALILAFI;Initial Catalog=Fileworx;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        string q;
        public void Run()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public List<PhotoDTO> ReadAllPhotos()
        {

            Run();
            q = $"SELECT C_ID, C_description, C_name, C_body,C_location, C_creation_date FROM dbo.T_BusinessObject B  INNER JOIN dbo.T_File F  ON B.C_ID = F.ID  Inner Join dbo.T_Photo P on F.id=P.ID WHERE  C_class_id=2";

            List<PhotoDTO> list = new List<PhotoDTO>();

            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PhotoDTO dt = new PhotoDTO(reader.GetString(2),reader.GetString(1),reader.GetDateTime(5),reader.GetInt32(0),reader.GetString(3),reader.GetString(4),3);
                list.Add(dt);

            }

            conn.Close();

            return list;
        }

        public List<PhotoDTO> SearchPhotos(string query)
        {
            Run();
            q = $"SELECT C_ID, C_description, C_name, C_body,C_location, C_creation_date FROM dbo.T_BusinessObject B  INNER JOIN dbo.T_File F  ON B.C_ID = F.ID  Inner Join dbo.T_Photo P on F.id=P.ID WHERE  C_class_id=2 AND CONCAT ( LOWER(B.C_name),  lower(B.C_description) , lower(B.C_creation_date)  , lower(F.C_body) , lower(P.C_location) ) like \'%{query}%\';";
            List<PhotoDTO> list = new List<PhotoDTO>();
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PhotoDTO dto = new PhotoDTO(reader.GetString(2), reader.GetString(1), reader.GetDateTime(5), reader.GetInt32(0), reader.GetString(3), reader.GetString(4), 3);
                list.Add(dto);
            }

            return list;

        }

        public void Close()
        {
            conn.Close();

        }
    }
}
