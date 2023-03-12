using FileworxWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Fileworx_Client;
using FileworxObjects.Objects;

namespace FileworxWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ApiRequests req = new();

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentials log)
        {
            int id = await req.GetLoginInfo(log.userName, log.password);
            if (id != -1)
            {          
                HttpContext.Session.SetString("loggedIn", "in");
                HttpContext.Session.SetInt32("modifier",id);
                return RedirectToAction("index", "");
            }
            return View();
        }

        public async Task<IActionResult> Index(string query, string [] categories , DateTime? before, DateTime? after)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            SearchObject search = new();
            if (before == null)
            {
                before = DateTime.MaxValue;
            }
            if(after == null)
            {
                after = DateTime.MinValue;
            }


            search.Before = before;
            search.After = after;
            search.Query = query;
            search.Categories = categories.ToList();
            
            List<FileModel> newsList = await req.GetSearch<FileModel>("News", search);
            List<FileModel> photoList = await req.GetSearch<FileModel>("Photos", search);
            List<FileModel> fileList = newsList.Concat(photoList).ToList();
            return View(fileList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}