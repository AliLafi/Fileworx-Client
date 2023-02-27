using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.Objects
{
    public partial class News : File
    {

        public string Category { get; set; }


        public News(string name, string description, DateTime created, int id, string body, string category) : base(name, description, created, id, body, 1)
        {
            Category = category;
        }

        public News(string name, string description, DateTime created, string body, string category) : base(name, description, created, body, 1)
        {
            Category = category;
            
        }
        public News() { }

        public override string ToString()
        {
            return $"{Name}%{Created}%{Description}%{Category}%{Body}";
        }

    }

}
