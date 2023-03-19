using System;

namespace FileworxObjects.DTOs
{
    public class PhotoDTO : FileDTO
    {
        public string ImagePath { get; set; }

        public PhotoDTO(string imagePath,int contactId, string body, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(contactId, body, id, lastModifier, creator, name, description, created, modifyDate, 2)
        {
            ImagePath = imagePath;
        }

        public PhotoDTO(string imagePath, int contactId, string body, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(contactId,body, lastModifier, creator, name, description, created, modifyDate, 2)
        {
            ImagePath = imagePath;
        }

        public PhotoDTO()
        {
        }

    }
}
