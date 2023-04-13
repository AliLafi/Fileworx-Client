using System;

namespace FileworxObjects.DTOs
{
    public  class ContactDTO : BusinessObjectDTO
    {
        public string SendFilePath { get; set; }
        public string ReceiveFilePath { get; set; }
        public DateTime LastFileReceptionDate { get; set; }
        public bool IsReadFile { get; set; }
        public bool IsWriteFile { get; set; }
        public bool IsReadFtp { get; set; }
        public bool IsWriteFtp { get; set; }
        public bool IsWriteTelegram { get; set; }
        public string SendFtpPath { get; set; }
        public string ReceiveFtpPath { get; set; }
        public DateTime LastFtpReceptionDate { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string TelegramUsername { get; set; }

        public ContactDTO(bool isRead, bool isWrite, string send, string recieve, DateTime lastReceptionDate, bool isWriteFtp, bool isReadFtp, string sendFtp, string recieveFtp, DateTime lastReceptionDateFtp,string host,string username,string password, bool isWriteTelegram, string telegramUsername, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified) : base(id, lastModifier, creator, name, description, created, lastModified, 4)
        {
            Host = host;
            Username = username;
            Password = password;
            LastFileReceptionDate = lastReceptionDate;
            IsReadFile = isRead;
            IsWriteFile = isWrite;
            SendFilePath = send;
            ReceiveFilePath = recieve;
            IsReadFtp= isReadFtp;
            IsWriteFtp = isWriteFtp;
            SendFtpPath= sendFtp;
            ReceiveFtpPath= recieveFtp;
            LastFtpReceptionDate= lastReceptionDateFtp;
            IsWriteTelegram= isWriteTelegram;
            TelegramUsername = telegramUsername;
        }

        public ContactDTO(bool isRead, bool isWrite, string send, string recieve, DateTime lastReceptionDate, bool isWriteFtp, bool isReadFtp, string sendFtp, string recieveFtp, DateTime lastReceptionDateFtp,string host,string username ,string password, bool isWriteTelegram, string telegramUsername, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified) : base(lastModifier, creator, name, description, created, lastModified, 4)
        {
            Host = host;
            Username = username;
            Password = password;
            IsReadFile = isRead;
            IsWriteFile = isWrite;
            SendFilePath = send;
            ReceiveFilePath = recieve;
            LastFileReceptionDate = lastReceptionDate;
            IsReadFtp = isReadFtp;
            IsWriteFtp = isWriteFtp;
            SendFtpPath = sendFtp;
            ReceiveFtpPath = recieveFtp;
            LastFtpReceptionDate = lastReceptionDateFtp;
            IsWriteTelegram = isWriteTelegram;
            TelegramUsername = telegramUsername;
        }

        public ContactDTO() { }
    }
}
