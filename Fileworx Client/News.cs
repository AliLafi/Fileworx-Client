using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileworx_Client
{
    internal class News : Media
    {
        public enum categories
        {
            General,
            Politics,
            Sports,
            Health

        }


        public string Category { get; set; }

        public News(string title, DateTime created, string description, string category, string body, Guid guid) : base(title, description, created, body, guid)
        {
            Category = category;
        }

        public News(string title, DateTime created, string description, string category, string body) : base(title, description, created, body)
        {
            Category = category;
        }

        public override string ToString()
        {
            return $"{Title}%{Created}%{Description}%{Category}%{Body}";
        }

    }

}
