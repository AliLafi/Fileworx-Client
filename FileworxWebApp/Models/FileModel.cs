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
       
        public IFormFile? Image { get; set; }
        public string ImageName { get; set; }

        public static readonly List<string> Categories = new()
        {
            "Politics",
            "General",
            "Sports",
            "Health"
        };
        public static readonly string SharedFolder = "D:\\SharedPhotos\\";
        public FileModel(string category,IFormFile image,string imageName, int contactId, string body, int id, int lastModifier, int creator, string name, string description, DateTime created, DateTime modifyDate,int classId)
        {
            Category = category;
            Image = image;
            Body = body;
                ID = id;
            LastModifier = lastModifier;
            Creator = creator;
            Name = name;
            Description = description;
            Created = created;
            ModifyDate = modifyDate;
            ContactID = contactId;
            ClassID= classId;
            ImageName= imageName;
        }

        public FileModel()
        {
        }
    }
}
