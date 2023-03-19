using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileworxWebApp.Models
{
    public class ContactModel
    {
        [DisplayName("Send Path")]
        public string? SendPath { get; set; }

        [DisplayName("Receive Path")]
        public string? ReceivePath { get; set; }

        [DisplayName("Last Reception Date")]
        public DateTime LastReceptionDate { get; set; }

        public int ID { get; set; }

        [DisplayName("Last Modifier")]
        public int LastModifier { get; set; }
        public int Creator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        [DisplayName("Last Modified")]
        public DateTime LastModified { get; set; }
        public int ClassID { get; set; }
        
        [DisplayName("Read")]
        public bool IsRead { get; set; }
        [DisplayName("Write")]
        public bool IsWrite { get; set; }
        
        public ContactModel(bool isRead , bool isWrite, string send, string recieve, DateTime lastReceptionDate, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime lastModified) 
        {
            ID = id;
            LastModifier = lastModifier;
            Creator = creator;
            Name = name;
            Description = description;
            Created = created;
            LastReceptionDate = lastReceptionDate;
            ClassID = 4;
            LastModified = lastModified;
            LastReceptionDate = lastReceptionDate;
            IsWrite = isWrite;
            IsRead = isRead;
            ReceivePath = recieve;
            SendPath = send;
        }

        


        public ContactModel() { }
    }
}

