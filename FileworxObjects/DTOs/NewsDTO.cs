using System;

namespace FileworxObjects.DTOs
{
    public class NewsDTO : FileDTO
    {
        public string Category { get; set; }

        public NewsDTO(string category, int contactId,string body, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(contactId,body, id, lastModifier, creator, name, description, created, modifyDate, 1)
        {
            Category = category;
        }

        public NewsDTO(string category,int contactId, string body, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(contactId,body, lastModifier, creator, name, description, created, modifyDate, 1)
        {
            Category = category;
        }

        public NewsDTO()
        {
        }

    }
}
