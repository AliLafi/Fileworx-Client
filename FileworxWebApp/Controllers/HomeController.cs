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
        ApiRequests req = new ApiRequests();

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

        public async Task<IActionResult> Index(string query, string [] categories , DateTime start, DateTime end)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }

            SearchObject search = new();

            if (end == DateTime.MinValue)
                end = DateTime.MaxValue;

            search.Start = start;
            search.End = end;
            search.Query = query;
            search.Categories = categories.ToList();
            
            List<FileModel> list = await req.GetSearch<FileModel>("News", search);
            List<FileModel> list2 = await req.GetSearch<FileModel>("Photos", search);
            List<FileModel> list3 = list.Concat(list2).ToList();
            return View(list3);
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