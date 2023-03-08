using Fileworx_Client;
using FileworxObjects.DTOs;
using FileworxWebApp.Mappers;
using FileworxWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileworxWebApp.Controllers
{
    public class NewsController : Controller
    {
        readonly ApiRequests req = new ApiRequests();

        public IActionResult  Create()
        {

            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FileModel f) {

            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            if (ModelState.IsValid)
            {
                NewsDTO news = FileMapper.FileToNewsDto(f);
                await req.Create("news", news);
            }

            return RedirectToAction("Index", "");
        }

        [Route("/1/edit/{id}")]
        public async Task<IActionResult> EditView(int ID)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            FileModel file = await req.GetByID<FileModel>("news", ID);
            return View(file);
        }

        [HttpPost]
        [Route("/1/edit/{id}")]
        public async Task<IActionResult> Edit(FileModel f)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            if (ModelState.IsValid)
            {
                NewsDTO news = FileMapper.FileToNewsDto(f);
                await req.Update("news", news);
            }

            return RedirectToAction("Index", "");
        }

        [HttpGet]
        [Route("1/view/{id}")]
        public async Task<IActionResult> NewsView(int ID)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            NewsDTO news = await req.GetByID<NewsDTO>("news", ID);
            FileModel file = FileMapper.NewsDtoToFile(news);
            return View(file);
        }

        [Route("/1/delete/{id}")]
        public async Task<IActionResult> DeleteNews(int ID)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            await req.Delete("news", ID);
            return RedirectToAction("Index", "");
        }
    }
}
