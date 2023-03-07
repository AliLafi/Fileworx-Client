using FileworxWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FileworxObjects.DTOs;
using FileworxObjects;
using System.Net.Http;
using Newtonsoft.Json;
using Fileworx_Client;
using FileworxObjects.Objects;
using System.Reflection;

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
            bool logged = await req.getLoginInfo(log.userName, log.password);
            if(logged)
            {
                this.HttpContext.Session.SetString("loggedIn", "in");
                return RedirectToAction("index", "");

            }
            Console.WriteLine(logged.ToString());

            return View();
        }

        public async Task<IActionResult> Index(string query, List<string> cat, DateTime start, DateTime end)
        {
            if(HttpContext.Session.GetString("loggedIn")!="in")
            {
              return  RedirectToAction("login","home");
            }
            List<FileModel> list = new List<FileModel>();
            List<FileModel> list2 = new List<FileModel>();
            List<FileModel> list3 = new List<FileModel>();

            SearchObject search = new SearchObject();

            if (end == DateTime.MinValue)
                end = DateTime.MaxValue;

            search.Start = start;
            search.End = end;
            search.query = query;
            search.categories = cat;
            list = await req.GetSearch<FileModel>("News", search);
            list2 = await req.GetSearch<FileModel>("Photos", search);

            list3 = list.Concat(list2).ToList();

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