using FileworxObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileworxObjects.Objects;
namespace FileworxObjects.Mappers
{
    public class NewsMapper
    {

        public static News DtoToNews(NewsDTO dto)
        {

            if (dto.ID == -1)
            {
                return new News(dto.Name, dto.Description, dto.Created, dto.Body, dto.Category);
            }

            else
            {
                return new News(dto.Name, dto.Description, dto.Created, dto.ID, dto.Body, dto.Category);
            
            }

        }
        public static NewsDTO NewsToDto(News news)
        {
            if(news.ID == -1)
            {
               return new NewsDTO(news.Name,news.Description,news.Created,news.Body,news.Category);

            }
            else
            {
                return new NewsDTO(news.Name,news.Description,news.Created,news.ID,news.Body,news.Category);
            }

        }
    
    
    
    }
}
