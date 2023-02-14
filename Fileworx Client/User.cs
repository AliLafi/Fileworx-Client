using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileworx_Client
{
    public class User
    {

        public Guid guid { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string LastModifier { get; set; }

        public User(string name, string loginName, string password, string lastModifier, Guid guid)
        {
            Name = name;
            LoginName = loginName;
            Password = password;
            LastModifier = lastModifier;
            this.guid = guid;
        }

        public User(string name, string loginName, string password, string lastModifier)
        {
            Name = name;
            LoginName = loginName;
            Password = password;
            LastModifier = lastModifier;
            guid = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{Name}%{LoginName}%{Password}%{LastModifier}";
        }

    }

}
