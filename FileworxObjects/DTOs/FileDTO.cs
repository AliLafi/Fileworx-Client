using System;

namespace FileworxObjects.DTOs
{
    public class FileDTO : BusinessObjectDTO
    {
        public string Body { get; set; }
        public int ContactId { get; set; }
        public FileDTO(int contactID,string body, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate, int classID) : base(id, lastModifier, creator, name, description, created, modifyDate, classID)
        {
            ContactId = contactID;
            Body = body;
        }
        public FileDTO(int contactId,string body, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate, int classID) : base(lastModifier, creator, name, description, created, modifyDate, classID)
        {
            ContactId = contactId;
            Body = body;
        }

        public FileDTO()
        {
        }
    }
}
