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
                q = $"UPDATE  dbo.T_Contact SET C_receive_file_path =\'{ReceiveFilePath}\' ," +
                    $"C_send_file_path = \'{SendFilePath}\'," +
                    $"C_last_file_reception_date = \'{LastFileReceptionDate}\'," +
                    $"C_is_read_file = \'{IsReadFile}\'," +
                    $"C_is_write_file = \'{IsWriteFile}\'," +
                    $"C_is_write_ftp = \'{IsWriteFtp}\'," +
                    $"C_is_read_ftp = \'{IsReadFtp}\'," +
                    $"C_send_ftp_path = \'{SendFtpPath}\'," +
                    $"C_receive_ftp_path = \'{ReceiveFtpPath}\'," +
                    $"C_last_ftp_reception_date = \'{LastFtpReceptionDate}\'," +
                    $"C_host = \'{Host}\'," +
                    $"C_password = \'{Password}\'," +
                    $"C_username = \'{Username}\'," +
                    $"C_is_write_telegram = \'{IsWriteTelegram}\'," +
                    $"C_telegram_username = \'{TelegramUsername}\'" +
                    $" WHERE ID = \'{ID}\'; ";
                cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                base.DBUpdate();
                q = $"INSERT INTO dbo.T_Contact (ID,C_receive_file_path,C_send_file_path,C_last_file_reception_date,C_is_read_file,C_is_write_file,C_receive_ftp_path,C_send_ftp_path,C_last_ftp_reception_date,C_is_read_ftp,C_is_write_ftp,C_host,C_username,C_password,C_is_write_telegram,C_telegram_username)" +
                    $" VALUES(\'{ID}\',\'{ReceiveFilePath}\',\'{SendFilePath}\',\'{LastFileReceptionDate}\',\'{IsReadFile}\',\'{IsWriteFile}\',\'{ReceiveFtpPath}\',\'{SendFtpPath}\',\'{LastFtpReceptionDate}\',\'{IsReadFtp}\',\'{IsWriteFtp}\',\'{Host}\',\'{Username}\',\'{Password}\',\'{IsWriteTelegram}\',\'{TelegramUsername}\');";
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
                ReceiveFilePath = r["C_receive_file_path"].ToString();
                SendFilePath = r["C_send_file_path"].ToString() ;
                ReceiveFtpPath = r["C_receive_ftp_path"].ToString();
                SendFtpPath = r["C_send_ftp_path"].ToString();
                IsWriteFile = bool.Parse(r["C_is_write_file"].ToString());
                IsReadFile = bool.Parse(r["C_is_read_file"].ToString());
                IsWriteFtp = bool.Parse(r["C_is_write_ftp"].ToString());
                IsReadFtp = bool.Parse(r["C_is_read_ftp"].ToString());
                IsWriteTelegram = bool.Parse(r["C_is_write_telegram"].ToString());
                LastFileReceptionDate = DateTime.Parse(r["C_last_file_reception_date"].ToString());
                LastFtpReceptionDate = DateTime.Parse(r["C_last_ftp_reception_date"].ToString());
                Host = r["C_host"].ToString();
                Username = r["C_username"].ToString();
                Password = r["C_password"].ToString();
                TelegramUsername = r["C_telegram_username"].ToString();
                ID = int.Parse(r["ID"].ToString());
            }

            r.Close();
        }

    }
}
