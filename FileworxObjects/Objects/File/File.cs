using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileworxObjects
{
    public partial class File : BusinessObject
    {
        public string Body { get; set; }

        public File(string name, string description, DateTime created, int id, string body, int classid) : base(name, description, created, id, classid)
        {
            Body = body;
        }

        public File(string name, string description, DateTime created, string body, int classid) : base(name, description, created, classid)
        {
            Body = body;
        }

        public File() { }

    }
}
