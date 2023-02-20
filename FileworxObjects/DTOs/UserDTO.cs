using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileworxObjects.DTOs
{
    public class UserDTO : BusinessObjectDTO
    {

        public string LoginName { get; set; }
        public string Password { get; set; }
        public string LastModifier { get; set; }



        public UserDTO() { }
        public UserDTO(string name, string description, DateTime created, int id, string loginName, string password, string lastmodifier) : base(name, description, created, id, 3)
        {
            LoginName = loginName;
            Password = password;
            LastModifier = lastmodifier;

        }

        public UserDTO(string name, string description, DateTime created, string loginName, string password, string lastmodifier) : base(name, description, created, 3)
        {
            LoginName = loginName;
            Password = password;
            LastModifier = lastmodifier;

        }

        public override string ToString()
        {
            return $"{Name}%{LoginName}%{Password}%{LastModifier}%{ID}";
        }
    }
}
