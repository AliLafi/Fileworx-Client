using System;

namespace FileworxObjects
{
    public partial class File : BusinessObject
    {
        public string Body { get; set; }
        public int ContactID { get; set; }
        public File(int contactID,string body,int id , int lastModifier , int creator , string name , string description , DateTime created , DateTime modifyDate, int classID) : base(id, lastModifier, creator, name, description, created, modifyDate, classID)
        {
            ContactID= contactID;
            Body= body;
        }
        public File(int contactID,string body, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate, int classID) : base(lastModifier, creator, name, description, created, modifyDate, classID)
        {
            ContactID = contactID;

            Body = body;
        }

        public File() 
        {
        }
    }
}
