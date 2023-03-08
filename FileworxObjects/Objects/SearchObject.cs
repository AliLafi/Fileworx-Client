using System;
using System.Collections.Generic;

namespace FileworxObjects.Objects
{
    public class SearchObject
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> Categories { get; set; }
        public string Query { get; set; }

        public SearchObject() { }
        public SearchObject(DateTime start, DateTime end, List<string> categories, string query)
        {
            Start = start;
            End = end;
            Categories = categories;
            Query = query;
        }
    }
}
