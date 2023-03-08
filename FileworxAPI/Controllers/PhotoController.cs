using FileworxObjects;
using Microsoft.AspNetCore.Mvc;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using Nest;
using FileworxObjects.Connection;
using Microsoft.Extensions.Logging;

namespace FileworxAPI.Controllers
{
    public class PhotoController : Controller
    {
        ElasticClient elasticClient = ElasticConnection.GetESClient();

        [HttpGet("Photos/{id}")]
        public JsonResult GetNewsByID(int id)
        {
            Photo photo = new()
            {
                ID = id
            };
            photo = photo.Read();

            return Json(photo);
        }

        [HttpGet("/Photos")]
        public JsonResult GetPhotos()
        {
            List<PhotoDTO> list;
            PhotoQuery photoQuery = new();

            list = photoQuery.Run(elasticClient, DateTime.MinValue,DateTime.MaxValue);
            return Json(list);

        }

        [HttpGet("/Photos/search")]
        public JsonResult SearchPhotos([FromQuery] DateTime? before, [FromQuery] DateTime? after,  [FromQuery] string query)
        {
            List<PhotoDTO> list;
            PhotoQuery photoQuery = new();
            if (after == null)
            {
                after = DateTime.MinValue;
            }
            if (before == null)
            {
                before = DateTime.MaxValue;
            }
            list = photoQuery.Run(elasticClient, after, before, query);
            return Json(list);
        }

        [HttpDelete("/Photo/{id}")]
        public string DeletePhoto(int id)
        {
            Photo photo = new()
            {
                ID = id
            };

            photo.Delete();
            return "Deleted Successfully";
        }

        [HttpPost("/Photo")]
        public string AddPhoto([FromBody] PhotoDTO dto)
        {
            Photo photo = PhotoMapper.DtoToPhoto(dto);
            photo.Update();
            return "Added Successfully";
        }

        [HttpPut("/Photo")]
        public string UpdatePhoto([FromBody] PhotoDTO dto)
        {
            Photo photo = PhotoMapper.DtoToPhoto(dto);
            photo.Update();
            return "Updated Successfully";
        }
    }
}
