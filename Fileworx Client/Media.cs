using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fileworx_Client
{
    internal abstract class Media
    {

        public  Guid guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Body { get; set; }

        // constructor for existing object
        public Media(string title, string description, DateTime created,string body,Guid guid)
        {
            Title = title;
            Description = description;
            Created = created;
            Body = body;
            this.guid = guid;
        }

        // constructor for new object new guid is created for file name
        public Media(string title, string description, DateTime created, string body)
        {
            Title = title;
            Description = description;
            Created = created;
            Body = body;
            this.guid = Guid.NewGuid();
        }

    }

}
