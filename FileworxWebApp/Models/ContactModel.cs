using System.ComponentModel;

namespace FileworxWebApp.Models
{
    public class ContactModel
    {
        [DisplayName("File Transmission Path")]
        public string? SendFilePath { get; set; }

        [DisplayName("File Reception Path")]
        public string? ReceiveFilePath { get; set; }

        [DisplayName("Ftp Transmission Path")]
        public string? SendFtpPath { get; set; }

        [DisplayName("Ftp Reception Path")]
        public string? ReceiveFtpPath { get; set; }

        [DisplayName("Last Ftp Reception Date")]
        public DateTime LastFtpReceptionDate { get; set; }

        [DisplayName("Last Reception Date")]
        public DateTime LastFileReceptionDate { get; set; }

        public int ID { get; set; }

        [DisplayName("Last Modifier")]
        public int LastModifier { get; set; }
        public int Creator { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }

        [DisplayName("Last Modified")]
        public DateTime LastModified { get; set; }
        public int ClassID { get; set; }
        
        [DisplayName("File Reception")]
        public bool IsReadFile { get; set; }
        [DisplayName("File Transmission")]
        public bool IsWriteFile { get; set; }
        [DisplayName("Ftp Reception")]
        public bool IsReadFtp { get; set; }
        [DisplayName("Ftp Reception")]
        public bool IsWriteFtp { get; set; }
        [DisplayName("Telegram Reception")]
        public bool IsWriteTelegram { get; set; }
        public string? Host { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        [DisplayName("Telegram Username")]
        public string? TelegramUsername { get; set; }

        public ContactModel(bool isRead , bool isWrite, string send, string recieve, DateTime lastReceptionDate,  bool isWriteFtp, bool isReadFtp, string sendFtp, string recieveFtp, DateTime lastReceptionDateFtp, string host,string username,string password, bool isWriteTelegram, string telegramUsername, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified) 
        {
            Host = host;
            Password= password;
            Username = username;
            ID = id;
            LastModifier = lastModifier;
            Creator = creator;
            Name = name;
            Description = description;
            Created = created;
            LastFileReceptionDate = lastReceptionDate;
            ClassID = 4;
            LastModified = lastModified;
            LastFileReceptionDate = lastReceptionDate;
            LastFtpReceptionDate = lastReceptionDateFtp;
            TelegramUsername= telegramUsername;

            IsWriteFile = isWrite;
            IsReadFile = isRead;
            IsWriteFtp = isWriteFtp;   
            IsReadFtp = isReadFtp;
            IsWriteTelegram = isWriteTelegram;

            ReceiveFilePath = recieve;
            SendFilePath = send;
            SendFtpPath= sendFtp;
            ReceiveFtpPath= recieveFtp;
        }

        


        public ContactModel() { }
    }
}

