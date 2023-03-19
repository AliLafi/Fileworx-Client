using System;

namespace FileworxObjects.Objects
{
    public partial class News : File
    {
        public string Category { get; set; }

        public News(string category,int contactId,string body, int id , int lastModifier, int creator , string name,string description , DateTime created ,DateTime modifyDate ):base(contactId,body,id,lastModifier,creator,name,description,created,modifyDate,1)
        {
            Category = category;
        }

        public News(string category, int contactId, string body,  int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(contactId, body,  lastModifier, creator, name, description, created, modifyDate, 1)
        {
            Category = category;
        }

        public News() 
        {
        }

    }
}
