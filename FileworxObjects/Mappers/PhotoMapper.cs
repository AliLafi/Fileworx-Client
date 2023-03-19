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
                return new Photo(dto.ImagePath, dto.ContactId, dto.Body, dto.LastModifier, dto.Creator, dto.Name, dto.Description, dto.Created, dto.ModifyDate);
            }
            else
            {
                return new Photo(dto.ImagePath,dto.ContactId, dto.Body, dto.ID, dto.LastModifier, dto.Creator, dto.Name, dto.Description, dto.Created, dto.ModifyDate);
            }
        }

        public static PhotoDTO PhotoToDto(Photo photo)
        {
            if (photo.ID == -1)
            {
                return new PhotoDTO(photo.ImagePath, photo.ContactID, photo.Body, photo.LastModifier, photo.Creator, photo.Name, photo.Description, photo.Created, photo.ModifyDate);
            }
            else
            {
                return new PhotoDTO(photo.ImagePath, photo.ContactID,photo.Body, photo.ID, photo.LastModifier, photo.Creator, photo.Name, photo.Description, photo.Created, photo.ModifyDate);
            }
        }
        public static GridViewRows DtoToGridViewRows(PhotoDTO dto)
        {
            GridViewRows rows = new GridViewRows
            {
                Created = dto.Created,
                Name = dto.Name,
                Description = dto.Description,
                ID = dto.ID,
                ClassId = dto.ClassID
            };
            return rows;
        }
    }
}
