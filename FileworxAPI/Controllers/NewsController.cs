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
        readonly ElasticClient elasticClient = ElasticConnection.GetESClient();

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
            List<NewsDTO> newsList;
            NewsQuery newsQuery = new();

            newsList = newsQuery.Run(elasticClient, DateTime.MinValue, DateTime.MaxValue);
            return Json(newsList);
        }

        [HttpGet("/News/search")]
        public JsonResult SearchNews([FromQuery] DateTime? before, [FromQuery] DateTime? after, [FromQuery] string cat, [FromQuery] string query)
        {
            List<NewsDTO> list;
            NewsQuery newsQuery = new();

            if (after == null)
            {
                after = DateTime.MinValue;
            }
            if (before == null)
            {
                before = DateTime.MaxValue;
            }

            list = newsQuery.Run(elasticClient, after.Value, before.Value, cat, query);
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
