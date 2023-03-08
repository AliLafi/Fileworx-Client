using Microsoft.AspNetCore.Mvc;
using FileworxObjects;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using Nest;
using FileworxObjects.Connection;

namespace FileworxAPI.Controllers
{
    public class NewsController : Controller
    {
        ElasticClient elasticClient = ElasticConnection.GetESClient();

        [HttpGet("news/{id}")]
        public JsonResult GetNewsByID(int id)
        {
            News news = new()
            {
                ID = id
            };

            news = news.Read();
            return Json(news);
        }

        [HttpGet("/News")]
        public JsonResult GetNews()
        {
            List<NewsDTO> list;
            NewsQuery newsQuery = new();

            list = newsQuery.Run(elasticClient, DateTime.MinValue, DateTime.MaxValue);
            return Json(list);
        }

        [HttpGet("/News/search")]
        public JsonResult SerachNews([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string cat, [FromQuery] string query)
        {
            List<NewsDTO> list;
            NewsQuery newsQuery = new();

            if (end == start && end == DateTime.MinValue)
            {
                end = DateTime.MaxValue;
            }

            list = newsQuery.Run(elasticClient, start, end, cat, query);
            return Json(list);
        }

        [HttpDelete("/News/{id}")]
        public string DeleteNews(int id)
        {
            News news = new()
            {
                ID = id
            };

            news.Delete();

            return "Deleted Successfully";
        }

        [HttpPost("/News")]
        public string AddNews([FromBody] NewsDTO dto)
        {
            News news = NewsMapper.DtoToNews(dto);

            news.Update();
            return "Added Successfully";
        }

        [HttpPut("/News")]
        public string UpdateNews([FromBody] NewsDTO dto)
        {
            News news = NewsMapper.DtoToNews(dto);

            news.Update();
            return "Updated Successfully";
        }
    }
}
