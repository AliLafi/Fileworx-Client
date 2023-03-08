using FileworxObjects.DTOs;
using FileworxWebApp.Models;

namespace FileworxWebApp.Mappers
{
    public class FileMapper
    {
        public static NewsDTO FileToNewsDto(FileModel f)
        {
            var news = new NewsDTO();
            news.Name = f.Name;
            news.Description = f.Description;
            news.ClassID= f.ClassID;
            news.Created = f.Created;
            news.Category = f.Category;
            news.ID = f.ID;
            news.Body = f.Body;
            return news;

        }

        public static FileModel NewsDtoToFile(NewsDTO n)
        {
            var file = new FileModel();
            file.Name = n.Name;
            file.Description = n.Description;
            file.ClassID = n.ClassID;
            file.Created = n.Created;
            file.Category = n.Category;
            file.ID = n.ID;
            file.Body = n.Body;
            return file;
        }

        public static PhotoDTO FileToPhotoDto(FileModel f)
        {
            var photo = new PhotoDTO();
            photo.Name = f.Name;
            photo.Description = f.Description;
            photo.ClassID = f.ClassID;
            photo.Created = f.Created;
            photo.ImagePath = f.ImagePath;
            photo.ID = f.ID;
            photo.Body = f.Body;
            return photo;

        }

        public static FileModel PhotoDtoToFile(PhotoDTO p)
        {
            var file = new FileModel();
            file.Name = p.Name;
            file.Description = p.Description;
            file.ClassID = p.ClassID;
            file.Created = p.Created;
            file.ImagePath = p.ImagePath;
            file.ID = p.ID;
            file.Body = p.Body;
            return file;
        }
    }
}
