using System;

namespace FileworxObjects
{
    public partial class BusinessObject
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int ClassID { get; set; }

        public BusinessObject(string name, string description, DateTime created, int id, int classid)
        {
            Name = name;
            Description = description;
            Created = created;
            this.ID = id;
            ClassID = classid;
        }

        public BusinessObject(string name, string description, DateTime created, int classid)
        {
            Name = name;
            Description = description;
            Created = created;
            this.ID = -1;
            ClassID = classid;
        }
        public BusinessObject() 
        { 
        
        }
    }
}
