using FileworxObjects.DTOs;
using FileworxObjects.Objects;

namespace FileworxObjects.Mappers
{
    public class PhotoMapper
    {
        public static Photo DtoToPhoto(PhotoDTO dto)
        {
            if (dto.ID == -1)
            {
                return new Photo(dto.Name, dto.Description, dto.Created, dto.Body, dto.ImagePath, dto.ClassID);
            }
            else
            {
                return new Photo(dto.Name, dto.Description, dto.Created, dto.ID, dto.Body, dto.ImagePath, dto.ClassID);
            }
        }

        public static PhotoDTO PhotoToDto(Photo photo)
        {
            if (photo.ID == -1)
            {
                return new PhotoDTO(photo.Name, photo.Description, photo.Created, photo.Body, photo.ImagePath, photo.ClassID);
            }
            else
            {
                return new PhotoDTO(photo.Name, photo.Description, photo.Created, photo.ID, photo.Body, photo.ImagePath, photo.ClassID);
            }
        }
    }
}
