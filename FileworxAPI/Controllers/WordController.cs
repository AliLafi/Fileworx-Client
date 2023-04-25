using FileworxAPI.Utilities;
using FileworxObjects;
using FileworxObjects.Objects;
using Microsoft.AspNetCore.Mvc;

namespace FileworxAPI.Controllers
{
    public class WordController : Controller
    {
        ApiRequests apiRequests = new ApiRequests();

        [HttpPost("/Word/News/{id}")]
        public ActionResult? SaveNewsWord(int id)
        {
            News news = new()
            {
                ID = id
            };

            news = news.Read();
            try
            {
                Stream stream = WordProcessing.SaveNews(news);

                return File(stream, "application/octet-stream", $"{news.Name}.docx");
            }
            catch
            {
                return null;
            }

        }

        [HttpPost("/Word/Photo/{id}")]
        public ActionResult? SavePhotoWord(int id)
        {
            Photo photo = new()
            {
                ID = id
            };

            photo = photo.Read();
            try
            {
                Stream stream = WordProcessing.SavePhoto(photo);

                return File(stream, "application/octet-stream", $"{photo.Name}.docx");
            }
            catch
            {
                return null;
            }

        }

        [HttpPost("Word/News/List")]
        public async Task<ActionResult?> SaveNewsList()
        {
            List<News> news = await apiRequests.GetAll<News>("News");

            try
            {
                Stream stream = WordProcessing.ExportNewsList(news);
                return File(stream, "application/octet-stream", $"NewsList.docx");
            }
            catch
            {
                return null;
            }

        }

        [HttpPost("Word/Photo/List")]
        public async Task<ActionResult?> SavePhotosList()
        {
            List<Photo> photos = await apiRequests.GetAll<Photo>("Photos");

            try
            {
                Stream stream = WordProcessing.ExportPhotoList(photos);
                return File(stream, "application/octet-stream", $"PhotoList.docx");
            }
            catch
            {
                return null;
            }
        }

    }
}
