using System;

namespace FileworxObjects.Objects.Contact
{
    public partial class Contact : BusinessObject
    {
        public string SendPath { get; set; }
        public string ReceivePath { get; set; }
        public DateTime LastReceptionDate { get; set; }
        public bool IsRead { get;set; }
        public bool IsWrite { get; set; }  

        public Contact(bool isRead,bool isWrite,string send,string recieve ,DateTime lastReceptionDate, int id , int lastModifier , int creator , string name , string description , DateTime created , DateTime lastModified ) : base(id,lastModifier,creator,name , description,created , lastModified , 4)
        {
         
            LastReceptionDate= lastReceptionDate;
            IsRead = isRead;
            IsWrite= isWrite;
            if (isRead)
            {
                ReceivePath = recieve;
            }
            else
            {
                ReceivePath = "";
            }
            if (isWrite)
            {
                SendPath = send;
            }
            else
            {
                SendPath = "";
            }
        }

        public Contact(bool isRead, bool isWrite, string send, string recieve, DateTime lastReceptionDate, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified) : base(lastModifier, creator, name, description, created, lastModified, 4)
        {
            LastReceptionDate = lastReceptionDate;
            IsRead = isRead;
            IsWrite = isWrite;
            if (isRead)
            {
                ReceivePath = recieve;
            }
            else
            {
                ReceivePath = "";
            }

            if (isWrite)
            {
                SendPath = send;
            }
            else
            {
                SendPath = "";
            }
        }

        public Contact() { }
    }
}
