using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public partial class User : BusinessObject
    {


        public string LoginName { get; set; }
        public string Password { get; set; }
        public string LastModifier { get; set; }



        public User() { }
        public User(string name, string description, DateTime created, int id, int classid, string loginName, string password, string lastmodifier) : base(name, description, created, id, classid)
        {
            LoginName = loginName;
            Password = password;
            LastModifier = lastmodifier;
        }

        public User(string name, string description, DateTime created, int classid, string loginName, string password, string lastmodifier) : base(name, description, created, classid)
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
