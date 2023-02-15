using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public abstract class BusinessObject
    {
         
        public  int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Body { get; set; }

        // constructor for existing object
        public BusinessObject(string title, string description, DateTime created,string body,int id)
        {
            Title = title;
            Description = description;
            Created = created;
            Body = body;
            this.ID = id;
        }

        // constructor for new object new guid is created for file name
        public BusinessObject(string title, string description, DateTime created, string body)
        {
            Title = title;
            Description = description;
            Created = created;
            Body = body;
            ID = -1;
        }

  
    }

}
