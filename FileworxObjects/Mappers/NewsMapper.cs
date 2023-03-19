using FileworxObjects.DTOs;
using FileworxObjects.Objects;

namespace FileworxObjects.Mappers
{
    public class NewsMapper
    {
        public static News DtoToNews(NewsDTO dto)
        {
            if (dto.ID == -1)
            {
                return new News(dto.Category,dto.ContactId, dto.Body, dto.LastModifier,dto.Creator, dto.Name,dto.Description, dto.Created, dto.ModifyDate);
            }
            else
            {
                return new News(dto.Category,dto.ContactId, dto.Body, dto.ID, dto.LastModifier, dto.Creator, dto.Name, dto.Description, dto.Created, dto.ModifyDate);
            }
        }

        public static NewsDTO NewsToDto(News news)
        {
            if(news.ID == -1)
            {
                return new NewsDTO(news.Category,news.ContactID, news.Body, news.LastModifier, news.Creator, news.Name, news.Description, news.Created, news.ModifyDate);
            }
            else
            {
                return new NewsDTO(news.Category,news.ContactID, news.Body,news.ID, news.LastModifier, news.Creator, news.Name, news.Description, news.Created, news.ModifyDate);
            }
        }

        public static GridViewRows DtoToGridViewRows(NewsDTO dto)
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