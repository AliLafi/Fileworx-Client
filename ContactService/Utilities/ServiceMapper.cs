using FileworxObjects.DTOs;

namespace WorkerService1.Utilities
{
    public class ServiceMapper
    {
        public static NewsDTO FileContentToNews(string content)
        {
            string[] attributes = content.Split("%");
            NewsDTO news = new(attributes[0], int.Parse(attributes[1]), attributes[2], int.Parse(attributes[3]), int.Parse(attributes[4]), int.Parse(attributes[5]), attributes[6], attributes[7], DateTime.Parse(attributes[8]), DateTime.Parse(attributes[9]))
            {
                ClassID = int.Parse(attributes[10])
            };
            return news;
        }

        public static PhotoDTO FileContentToPhoto(string content)
        {
            string[] attributes = content.Split("%");
            PhotoDTO photo = new(attributes[0], int.Parse(attributes[1]), attributes[2], int.Parse(attributes[3]), int.Parse(attributes[4]), int.Parse(attributes[5]), attributes[6], attributes[7], DateTime.Parse(attributes[8]), DateTime.Parse(attributes[9]))
            {
                ClassID = int.Parse(attributes[10])
            };
            return photo;
        }


    }
}
