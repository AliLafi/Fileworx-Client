using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.DTOs
{
    public class PhotoDTO : FileDTO
    {
        public string ImagePath { get; set; }

        public PhotoDTO(string name, string description, DateTime created, int id, string body, string imagepath, int classid=2) : base(name, description, created, id, body, 2)
        {
            ImagePath = imagepath;
        }

        public PhotoDTO(string name, string description, DateTime created, string body, string imgPath, int classid=2) : base(name, description, created, body, 2)
        {
            ImagePath = imgPath;
        }

        public PhotoDTO() 
        {
        }

        public override string ToString()
        {
            return $"{Name}%{Created}%{Description}%{ImagePath}%{Body}";
        }
    }
}
