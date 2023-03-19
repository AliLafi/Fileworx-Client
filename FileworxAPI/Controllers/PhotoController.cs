using Microsoft.AspNetCore.Mvc;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using Nest;
using FileworxObjects.Connection;
using FileworxObjects.DTOs;

namespace FileworxAPI.Controllers
{
    public class PhotoController : Controller
    {
        readonly ElasticClient elasticClient = ElasticConnection.GetESClient();

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
            List<PhotoDTO> photoList;
            PhotoQuery photoQuery = new();

            photoList = photoQuery.Run(elasticClient, DateTime.MinValue,DateTime.MaxValue);
            return Json(photoList);

        }

        [HttpGet("/Photos/search")]
        public JsonResult SearchPhotos([FromQuery] DateTime? before, [FromQuery] DateTime? after,  [FromQuery] string query)
        {
            List<PhotoDTO> photoList;
            PhotoQuery photoQuery = new();
            if (after == null)
            {
                after = DateTime.MinValue;
            }
            if (before == null)
            {
                before = DateTime.MaxValue;
            }
            photoList = photoQuery.Run(elasticClient, after.Value, before.Value, query);
            return Json(photoList);
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
            photo.ID = -1;
            photo.ClassID = 2;
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
