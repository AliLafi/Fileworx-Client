using Fileworx_Client;
using FileworxObjects.DTOs;
using FileworxWebApp.Mappers;
using FileworxWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileworxWebApp.Controllers
{
    public class PhotoController : Controller
    {
        ApiRequests req = new ApiRequests();

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FileModel f)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            if (ModelState.IsValid)
            {
                PhotoDTO photo = FileMapper.FileToPhotoDto(f);
                await req.Create("Photo", photo);
            }

            return RedirectToAction("Index", "");
        }

        [HttpGet]
        [Route("2/view/{id}")]
        public async Task<IActionResult> PhotoView(int ID)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            PhotoDTO photo = await req.GetByID<PhotoDTO>("Photos", ID);
            FileModel file = FileMapper.PhotoDtoToFile(photo);
            return View(file);
        }




        [Route("/2/edit/{id}")]
        public async Task<IActionResult> EditView(int ID)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
      
            PhotoDTO photo = await req.GetByID<PhotoDTO>("Photos", ID);
            FileModel file = FileMapper.PhotoDtoToFile(photo);
            return View(file);
        }

        [HttpPost]
        [Route("/2/edit/{id}")]
        public async Task<IActionResult> Edit(FileModel f)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            if (ModelState.IsValid)
            {
                PhotoDTO photo = FileMapper.FileToPhotoDto(f);
                await req.Update<PhotoDTO>("photo", photo);

            }

            return RedirectToAction("Index", "");
        }

        [Route("/2/delete/{id}")]
        public async Task<IActionResult> DeleteNews(int ID)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            ApiRequests req = new ApiRequests();
            await req.Delete("news", ID);
            return RedirectToAction("Index", "");
        }
    }
}
