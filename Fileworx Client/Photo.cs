using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Fileworx_Client
{
    internal class Photo : Media
    {

        public string ImagePath { get; set; }

        public Photo(string title, DateTime created, string description,  string imgPath,string body, Guid guid) : base(title, description, created, body, guid)
        {
            ImagePath = imgPath;
        }

        public Photo(string title, DateTime created, string description, string imgPath, string body) : base(title, description, created, body)
        {
            ImagePath = imgPath;
        } 

        public override string ToString()
        {
            return $"{Title}%{Created}%{Description}%{ImagePath}%{Body}";
        } 

    }

}
