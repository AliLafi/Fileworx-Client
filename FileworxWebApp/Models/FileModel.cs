namespace FileworxWebApp.Models
{
    public class FileModel
    {
        public int ID { get; set; }
        public int LastModifier { get; set; }
        public int Creator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ClassID { get; set; }
        public int ContactID { get; set; }

        public string Body { get; set; }
       
        public string? Category { get; set; }
       
        public string? ImagePath { get; set; }

        public static readonly List<string> Categories = new()
        {
            "Politics",
            "General",
            "Sports",
            "Health"
        };

        public FileModel(string category,string imagePath, int contactId, string body, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate)
        {
            Category = category;
            ImagePath = imagePath;
            Body = body;
                ID = id;
            LastModifier = lastModifier;
            Creator = creator;
            Name = name;
            Description = description;
            Created = created;
            ModifyDate = modifyDate;
            ClassID = ClassID;
            ContactID = contactId;


        }

        public FileModel()
        {
        }
    }
}
