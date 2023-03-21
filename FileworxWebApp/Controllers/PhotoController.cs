using FileworxObjects;
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
            ViewBag.Modifier = HttpContext.Session.GetInt32("modifier");
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
                if(f.Image!= null)
                {
                   
                    f.ImageName =  Guid.NewGuid().ToString()+ Path.GetExtension(f.Image.FileName);
                   string folder =FileModel.SharedFolder+ f.ImageName;
                    await f.Image.CopyToAsync(new FileStream(folder, FileMode.Create));
                    
                }
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
            ViewBag.Modifier = HttpContext.Session.GetInt32("modifier");
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
        [Route("Photo/Edit")]
        public async Task<IActionResult> Edit(FileModel f)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            if (ModelState.IsValid)
            {
                if (f.Image != null)
                {

                    f.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(f.Image.FileName);
                    string folder = FileModel.SharedFolder + f.ImageName;
                    await f.Image.CopyToAsync(new FileStream(folder, FileMode.Create));

                }
                PhotoDTO photo = FileMapper.FileToPhotoDto(f);
                await req.Update<PhotoDTO>("photo", photo);

            }

            return RedirectToAction("Index", "");
        }

        [Route("/2/delete/{id}")]
        public async Task<IActionResult> DeletePhoto(int ID)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            ApiRequests req = new ApiRequests();
            await req.Delete("photo", ID);
            return RedirectToAction("Index", "");
        }
    }
}
