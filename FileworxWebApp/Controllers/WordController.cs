using FileworxObjects;
using Microsoft.AspNetCore.Mvc;

namespace FileworxWebApp.Controllers
{
    public class WordController : Controller
    {
        ApiRequests apiRequests = new ApiRequests();

        [HttpPost]
        public async Task<ActionResult> SaveNewsWord(int Id, string name)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
            Stream stream = await apiRequests.DownloadWord(Id, "News");
            if (stream == null)
                return NotFound();
            return File(stream, "application/octet-stream", $"{name}.docx");
        }

        [HttpPost]
        public async Task<ActionResult> SavePhotoWord(int Id, string name)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
            Stream stream = await apiRequests.DownloadWord(Id, "Photo");
            if (stream == null)
                return NotFound();
            return File(stream, "application/octet-stream", $"{name}.docx");
        }

        [HttpGet]
        public async Task<ActionResult> SavePhotoList()
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
            Stream stream = await apiRequests.DownloadWordList("Photo");
            if (stream == null)
            {
                return NotFound();
            }
            return File(stream, "application/octet-stream", "PhotosList.docx");
        }

        [HttpGet]
        public async Task<ActionResult> SaveNewsList()
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
            Stream stream = await apiRequests.DownloadWordList("News");
            if (stream == null)
            {
                return NotFound();
            }
            return File(stream, "application/octet-stream", "NewsList.docx");
        }
    }
}
