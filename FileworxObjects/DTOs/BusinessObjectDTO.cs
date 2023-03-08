using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.DTOs
{
    public class BusinessObjectDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int ClassID { get; set; }

        public BusinessObjectDTO(string name, string description, DateTime created, int id, int classid)
        {
            Name = name;
            Description = description;
            Created = created;
            this.ID = id;
            ClassID = classid;
        }

        public BusinessObjectDTO(string name, string description, DateTime created, int classid)
        {
            Name = name;
            Description = description;
            Created = created;
            this.ID = -1;
            ClassID = classid;
        }

        public BusinessObjectDTO() 
        { 

        }

    }
}
