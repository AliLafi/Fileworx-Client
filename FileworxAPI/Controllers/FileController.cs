using Microsoft.AspNetCore.Mvc;

namespace FileworxAPI.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
