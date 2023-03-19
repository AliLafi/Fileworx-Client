using System;

namespace FileworxObjects.Objects
{
    public partial class User : BusinessObject
    {
        public string LoginName { get; set; }
        public string Password { get; set; }

        public User(string loginName,string password, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(id, lastModifier, creator, name, description, created, modifyDate, 3)
        {
            LoginName= loginName;
            Password= password;
        }

        public User(string loginName, string password, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate) : base(lastModifier, creator, name, description, created, modifyDate, 3)
        {
            LoginName = loginName;
            Password = password;
        }

        public User()
        {
        }
    }
}
