using System;

namespace FileworxObjects.Objects.Contact
{
    public partial class Contact : BusinessObject
    {
        public string SendFilePath { get; set; }
        public string ReceiveFilePath { get; set; }
        public DateTime LastFileReceptionDate { get; set; }
        public bool IsReadFile { get;set; }
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


        public Contact(bool isRead,bool isWrite,string send,string recieve ,DateTime lastReceptionDate, bool isWriteFtp, bool isReadFtp, string sendFtp, string recieveFtp, DateTime lastReceptionDateFtp, string host,string username,string password,bool isWriteTelegram, string telegramUsername,int id , int lastModifier , int creator , string name , string description , DateTime created , DateTime lastModified ) : base(id,lastModifier,creator,name , description,created , lastModified , 4)
        {
            Host = host;
            Password= password;
            Username= username;
            LastFileReceptionDate= lastReceptionDate;
            LastFtpReceptionDate = lastReceptionDateFtp;
            IsReadFile = isRead;
            IsWriteFile= isWrite;
            IsReadFtp = isReadFtp;
            IsWriteFtp = isWriteFtp;
            IsWriteTelegram= isWriteTelegram;
            TelegramUsername = telegramUsername;

            if (IsReadFile)
            {
                ReceiveFilePath = recieve;
            }
            else
            {
                ReceiveFilePath = "";
            }
            if (IsWriteFile)
            {
                SendFilePath = send;
            }
            else
            {
                SendFilePath = "";
            }
            if (IsReadFtp)
            {
                ReceiveFtpPath = recieveFtp;
            }
            else
            {
                ReceiveFtpPath = "";
            }
            if (IsWriteFtp)
            {
                SendFtpPath = sendFtp;
            }
            else
            {
                SendFtpPath = "";
            }
        }

        public Contact(bool isRead, bool isWrite, string send, string recieve, DateTime lastReceptionDate, bool isWriteFtp, bool isReadFtp, string sendFtp, string recieveFtp, DateTime lastReceptionDateFtp, string host, string username, string password, bool isWriteTelegram, string telegramUsername, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified) : base(lastModifier, creator, name, description, created, lastModified, 4)
        {
            Host = host;
            Password = password;
            Username = username;
            LastFileReceptionDate = lastReceptionDate;
            LastFtpReceptionDate = lastReceptionDateFtp;
            IsReadFile = isRead;
            IsWriteFile = isWrite;
            IsReadFtp = isReadFtp;
            IsWriteFtp = isWriteFtp;
            IsWriteTelegram= isWriteTelegram;
            TelegramUsername = telegramUsername;

            if (isRead)
            {
                ReceiveFilePath = recieve;
            }
            else
            {
                ReceiveFilePath = "";
            }

            if (isWrite)
            {
                SendFilePath = send;
            }
            else
            {
                SendFilePath = "";
            }
            if (IsReadFtp)
            {
                ReceiveFtpPath = recieveFtp;
            }
            else
            {
                ReceiveFtpPath = "";
            }
            if (IsWriteFtp)
            {
                SendFtpPath = sendFtp;
            }
            else
            {
                SendFtpPath = "";
            }
        }

        public Contact() { }
    }
}
