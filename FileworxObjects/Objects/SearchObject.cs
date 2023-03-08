using System;
using System.Collections.Generic;

namespace FileworxObjects.Objects
{
    public class SearchObject
    {
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
        public List<string> Categories { get; set; }
        public string Query { get; set; }

        public SearchObject() { }
        public SearchObject(DateTime? after, DateTime? before, List<string> categories, string query)
        {
            Before = before;
            After = after;
            Categories = categories;
            Query = query;
        }
    }
}
