using Microsoft.AspNetCore.Mvc;
using System.Data;
using FileworxObjects;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using System.Text.Json;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using Nest;
using Newtonsoft.Json;
using FileworxObjects.Connection;

namespace FileworxAPI.Controllers
{


    public class NewsController : Controller
    {

        ElasticClient elasticClient = ElasticConnection.GetESClient();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/News")]
        public JsonResult GetNews()
        {


            List<NewsDTO> list;
            NewsQuery nq = new NewsQuery();

            list = nq.Run(elasticClient, DateTime.MinValue, DateTime.MaxValue);

            return Json(list);

        }

        [HttpGet("/News/search")]
        public JsonResult SerachNews([FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string cat, [FromQuery] string query)
        {


            List<NewsDTO> list;
            NewsQuery nq = new NewsQuery();
            if (end == start && end == DateTime.MinValue)
            {
                end = DateTime.MaxValue;
            }
            list = nq.Run(elasticClient, start, end, cat, query);

            return Json(list);
        }

        [HttpDelete("/News/{id}")]
        public string DeleteNews(int id)
        {
            News n = new News();
            n.ID = id;
            n.Delete();
            return "Deleted Successfully";
        }

        [HttpPost("/News")]
        public string AddNews([FromBody] NewsDTO dto)
        {
            News n = NewsMapper.DtoToNews(dto);
            n.Update();
            return "Added Successfully";
        }

        [HttpPut("/News")]
        public string UpdateNews([FromBody] NewsDTO dto)
        {
            News n = NewsMapper.DtoToNews(dto);
            n.Update();
            return "Updated Successfully";
        }



    }
}
