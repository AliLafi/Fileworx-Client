using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects.Objects
{
    public class SearchObject
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> categories { get; set; }
        public string query { get; set; }
        public SearchObject() { }
        public SearchObject(DateTime start, DateTime end, List<string> categories, string query)
        {
            Start = start;
            End = end;
            this.categories = categories;
            this.query = query;
        }
    }
}
