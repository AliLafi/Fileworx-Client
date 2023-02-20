using Microsoft.AspNetCore.Mvc;
using System.Data;
using FileworxObjects;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using System.Text.Json;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;

namespace FileworxAPI.Controllers
{
    public class NewsController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/News")]
        public JsonResult GetNews()
        {


            List<NewsDTO> list; 
            NewsQuery nq = new NewsQuery();
            list= nq.ReadAllNews();
            
            return Json(list);

        }

        [HttpGet("/News/{query}")]
        public JsonResult SerachNews(string query) 
        {
            List<NewsDTO> list; 
            NewsQuery nq = new NewsQuery();
            list = nq.SearchNews(query);

            return Json(list);
        }

        [HttpDelete("/News")]
        public string DeleteNews([FromBody] NewsDTO dto)
        {
            News n = NewsMapper.DtoToNews(dto);
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
