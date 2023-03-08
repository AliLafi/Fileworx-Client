using System;

namespace FileworxObjects
{
    public partial class User : BusinessObject
    {

        public string LoginName { get; set; }
        public string Password { get; set; }
        public int LastModifier { get; set; }

        public User() 
        {
        
        }

        public User(string name, string description, DateTime created, int id, int classid, string loginName, string password, int lastmodifier) : base(name, description, created, id, classid)
        {
            LoginName = loginName;
            Password = password;
            LastModifier = lastmodifier;
        }

        public User(string name, string description, DateTime created, int classid, string loginName, string password, int lastmodifier) : base(name, description, created, classid)
        {
            LoginName = loginName;
            Password = password;
            LastModifier = lastmodifier;

        }

        public override string ToString()
        {
            return $"{Name}%{LoginName}%{Password}%{LastModifier}";
        }
    }
}
