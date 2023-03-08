using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.Objects
{
    public class GridViewRows
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int ClassId { get; set; }    

        public GridViewRows() 
        {
        }
        public GridViewRows(int id, string name, string description,DateTime created)
        {
            ID = id;
            Name = name;
            Description = description;
            Created= created;
        }
    }
}
