namespace FileworxWebApp.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClassID { get; set; }
        public string Body { get; set; }
        public int ID { get; set; }
        public string? Category { get; set; }
        public DateTime Created { get; set; }
        public string? ImagePath { get; set; }

        public static List<string> Categories = new()
        {
            "Politics",
            "General",
            "Sports",
            "Health"
        };

        public FileModel(string name, string description, int classID, string body, int iD, string category, DateTime created, string imagePath)
        {
            Name = name;
            Description = description;
            ClassID = classID;
            Body = body;
            ID = iD;
            Category = category;
            Created = created;
            ImagePath = imagePath;
        }

        public FileModel()
        {
        }
    }
}
