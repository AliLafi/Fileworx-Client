using System;

namespace FileworxObjects.Objects
{
    public partial class Photo : File
    {
        public string ImagePath { get; set; }

        public Photo(string imagePath,int contactId, string body, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(contactId,body, id, lastModifier, creator, name, description, created, modifyDate, 2)
        {
            ImagePath = imagePath;
        }

        public Photo(string imagePath,int contactId, string body, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(contactId,body, lastModifier, creator, name, description, created, modifyDate, 2)
        {
            ImagePath = imagePath;
        }

        public Photo() 
        {
        }
        public override string ToString()
        {
            return $"{ImagePath}%{ContactID}%{Body}%{ID}%{LastModifier}%{Creator}%{Name}%{Description}%{Created}%{ModifyDate}%{ClassID}";
        }
    }
}
