using System.Data.SqlClient;

namespace FileworxObjects.Connection
{
    public class DBConnection
    {
        static readonly string connectionString = "Data Source=ALILAFI;Initial Catalog=Fileworx;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
