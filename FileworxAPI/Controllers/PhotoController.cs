using FileworxObjects;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using Nest;
using FileworxObjects.Connection;

namespace FileworxAPI.Controllers
{
    public class PhotoController : Controller
    {

        ElasticClient elasticClient = ElasticConnection.GetESClient();

        [HttpGet("Photos/{id}")]
        public JsonResult GetNewsByID(int id)
        {
            Photo p = new Photo();
            p.ID = id;
            p = p.Read();

            return Json(p);

        }
        [HttpGet("/Photos")]
        public JsonResult GetPhotos()
        {

            List<PhotoDTO> list;
            PhotoQuery pq = new PhotoQuery();

            list = pq.Run(elasticClient, DateTime.MinValue,DateTime.MaxValue);

            return Json(list);

        }

        [HttpGet("/Photos/search")]
        public JsonResult SearchPhotos([FromQuery] DateTime start, [FromQuery] DateTime end,  [FromQuery] string query)
        {


            List<PhotoDTO> list;
            PhotoQuery pq = new PhotoQuery();
            if (end == start && end == DateTime.MinValue)
            {
                end = DateTime.MaxValue;
            }
            list = pq.Run(elasticClient, start, end, query);

            return Json(list);
        }


        [HttpDelete("/Photo/{id}")]
        public string DeletePhoto(int id)
        {
            Photo photo = new Photo();
            photo.ID = id;
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
