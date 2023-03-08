using System;

namespace FileworxObjects.Objects
{
    public partial class Photo : File
    {
        public string ImagePath { get; set; }

        public Photo(string name, string description, DateTime created, int id, string body, string imagepath, int classid) : base(name, description, created, id, body, classid)
        {
            ImagePath = imagepath;
        }

        public Photo(string name, string description, DateTime created, string body, string imgPath, int classid) : base(name, description, created, body, classid)
        {
            ImagePath = imgPath;
        }

        public Photo() 
        {
        }

        public override string ToString()
        {
            return $"{Name}%{Created}%{Description}%{ImagePath}%{Body}";
        }
    }
}
