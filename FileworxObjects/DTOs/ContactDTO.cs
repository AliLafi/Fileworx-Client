using System;
using System.ComponentModel;

namespace FileworxObjects.DTOs
{
    public  class ContactDTO : BusinessObjectDTO
    {
        public string SendPath { get; set; }
        public string ReceivePath { get; set; }
        public DateTime LastReceptionDate { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }

        public ContactDTO(bool isRead, bool isWrite, string send, string recieve, DateTime lastReceptionDate, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified) : base(id, lastModifier, creator, name, description, created, lastModified, 4)
        {
            LastReceptionDate = lastReceptionDate;
            IsRead = isRead;
            IsWrite = isWrite;
            SendPath = send;
            ReceivePath = recieve;
        }

        public ContactDTO(bool isRead, bool isWrite, string send, string recieve, DateTime lastReceptionDate, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified) : base(lastModifier, creator, name, description, created, lastModified, 4)
        {
            IsRead = isRead;
            IsWrite = isWrite;
            SendPath = send;
            ReceivePath = recieve;
            LastReceptionDate = lastReceptionDate;

        }

        public ContactDTO() { }
    }
}
