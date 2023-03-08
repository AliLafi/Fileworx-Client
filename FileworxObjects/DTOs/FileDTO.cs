using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.DTOs
{
    public class FileDTO:BusinessObjectDTO
    {
        public string Body { get; set; }

        public FileDTO(string name, string description, DateTime created, int id, string body, int classid) : base(name, description, created, id, classid)
        {
            Body = body;
        }

        public FileDTO(string name, string description, DateTime created, string body, int classid) : base(name, description, created, classid)
        {
            Body = body;
        }

        public FileDTO()
        {
        }
    }
}
