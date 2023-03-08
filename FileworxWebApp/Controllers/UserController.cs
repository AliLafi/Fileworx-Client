using Fileworx_Client;
using FileworxObjects.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FileworxWebApp.Controllers
{
    public class UserController : Controller
    {
        ApiRequests req = new ApiRequests();
        bool exists = false;

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            ViewBag.Modifier = HttpContext.Session.GetInt32("modifier");
            return View(exists);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO user)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            if (ModelState.IsValid)
            {
                string x = await req.Create("User", user);
                if (x == "User Exists")
                {
                    exists = true;
                    return View(exists);
                }
            }

            return RedirectToAction("Index", "");
        }
    }
}
