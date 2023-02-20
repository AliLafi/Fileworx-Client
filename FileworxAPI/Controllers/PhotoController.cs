using FileworxObjects;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;

namespace FileworxAPI.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Photos")]
        public JsonResult GetPhotos()
        {

            List<PhotoDTO> list;
            PhotoQuery query = new PhotoQuery();
            list = query.ReadAllPhotos();

            return Json(list);

        }

        [HttpDelete("/Photo")]
        public string DeletePhoto([FromBody] PhotoDTO dto)
        {
            Photo photo = PhotoMapper.DtoToPhoto(dto);

            photo.Delete();
            return "Deleted Successfully";
        }

        [HttpPost("/Photo")]
        public string AddPhoto([FromBody] PhotoDTO dto)
        {
            Photo photo = PhotoMapper.DtoToPhoto(dto);
            photo.UpdatePhoto();
            return "Added Successfully";
        }

        [HttpPut("/Photo")]
        public string UpdatePhoto([FromBody] PhotoDTO dto)
        {
            Photo photo = PhotoMapper.DtoToPhoto(dto);
            photo.UpdatePhoto();
            return "Updated Successfully";
        }

    }

}
