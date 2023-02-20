using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileworxObjects.DTOs
{
    public class NewsDTO : FileDTO
    {
        public string Category { get; set; }


        public NewsDTO(string name, string description, DateTime created, int id, string body, string category) : base(name, description, created, id, body, 1)
        {
            Category = category;
        }

        public NewsDTO(string name, string description, DateTime created, string body, string category) : base(name, description, created, body, 1)
        {
            Category = category;
        }
        public NewsDTO() { }

        public override string ToString()
        {
            return $"{Name}%{Created}%{Description}%{Category}%{Body}";
        }
    }
}
