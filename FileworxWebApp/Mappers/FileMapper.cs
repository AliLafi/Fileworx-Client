using FileworxObjects.DTOs;
using FileworxWebApp.Models;
using System.Drawing;

namespace FileworxWebApp.Mappers
{
    public class FileMapper
    {
        public static NewsDTO FileToNewsDto(FileModel file)
        {
            var news = new NewsDTO
            {
                Name = file.Name,
                Description = file.Description,
                ClassID = file.ClassID,
                Created = file.Created,
                Category = file.Category,
                ID = file.ID,
                Body = file.Body,
                Creator = file.Creator,
                LastModifier = file.LastModifier,
                ModifyDate = file.ModifyDate,
                ContactId = file.ContactID
            };

            return news;

        }

        public static FileModel NewsDtoToFile(NewsDTO news)
        {
            var file = new FileModel
            {
                Name = news.Name,
                Description = news.Description,
                ClassID = news.ClassID,
                Created = news.Created,
                Category = news.Category,
                ID = news.ID,
                Body = news.Body,
                Creator = news.Creator,
                LastModifier = news.LastModifier,
                ModifyDate = news.ModifyDate
            };
            return file;
        }

        public static PhotoDTO FileToPhotoDto(FileModel file)
        {
            var photo = new PhotoDTO
            {
                Name = file.Name,
                Description = file.Description,
                ClassID = file.ClassID,
                Created = file.Created,
                ImagePath = file.ImageName,
                ID = file.ID,
                Body = file.Body,
                Creator= file.Creator,
                LastModifier = file.LastModifier,
                ModifyDate = file.ModifyDate

            };
            return photo;

        }

        public static FileModel PhotoDtoToFile(PhotoDTO photo)
        {
            var file = new FileModel
            {
                Name = photo.Name,
                Description = photo.Description,
                ClassID = photo.ClassID,
                Created = photo.Created,
                ID = photo.ID,
                Body = photo.Body,
                Creator = photo.Creator,
                LastModifier = photo.LastModifier,
                ModifyDate = photo.ModifyDate,
                ImageName = photo.ImagePath
            };
            return file;
        }
    }
}
