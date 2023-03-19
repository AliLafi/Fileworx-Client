using System;
using System.Data.SqlClient;

namespace FileworxObjects.Objects.Contact
{
    public partial class Contact
    {
        public override void DBUpdate()
        {
            
            if (ID > -1)
            {
                base.DBUpdate();
                q = $"UPDATE  dbo.T_Contact SET C_receive_file_path =\'{ReceivePath}\' ," +
                    $"C_send_file_path = \'{SendPath}\'," +
                    $"C_last_reception_date = \'{LastReceptionDate}\'," +
                    $"C_is_read = \'{IsRead}\'," +
                    $"C_is_write = \'{IsWrite}\'" +
                    $" WHERE ID = \'{ID}\'; ";
                cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                base.DBUpdate();
                q = $"INSERT INTO dbo.T_Contact (ID,C_receive_file_path,C_send_file_path,C_last_reception_date,C_is_read,C_is_write)" +
                    $" VALUES(\'{ID}\',\'{ReceivePath}\',\'{SendPath}\',\'{LastReceptionDate}\',\'{IsRead}\',\'{IsWrite}\');";
                cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public override void DBDelete()
        {
            if (ID > -1)
            {
                try
                {
                    CheckConnection();
                    q = $"DELETE FROM dbo.T_Contact WHERE ID =\'{ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    base.DBDelete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public override void DBRead()
        {
            base.DBRead();
            q = $"select * from dbo.T_Contact where ID = {ID}";
            cmd = new SqlCommand(q, conn);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                ReceivePath = r["C_receive_file_path"].ToString();
                SendPath = r["C_send_file_path"].ToString() ;
                IsWrite = bool.Parse(r["C_is_write"].ToString());
                IsRead = bool.Parse(r["C_is_read"].ToString());
                LastReceptionDate = DateTime.Parse(r["C_last_reception_date"].ToString());
                ID = int.Parse(r["ID"].ToString());
            }

            r.Close();
        }

    }
}
