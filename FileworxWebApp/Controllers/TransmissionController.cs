using FileworxObjects;
using FileworxObjects.DTOs;
using FileworxWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileworxWebApp.Controllers
{
    public class TransmissionController : Controller
    {
        readonly ApiRequests apiRequests = new();
        readonly WindowsServiceRequests windowsServiceRequests = new();

        [HttpGet("{classId}/Send/{id}")]
        public async Task<IActionResult> Index(int classId, int id)
        {
            List<ContactModel> Contacts = await apiRequests.GetAll<ContactModel>("contacts/send");
            ViewBag.classId = classId; 
            ViewBag.id = id;
            return View(Contacts);
        }

        [HttpGet("{classId}/Send/{id}/{contactId}")]
        public async Task<IActionResult> Send(int classId, int id, int contactId)
        {
            if(classId == 1) 
            {
                await windowsServiceRequests.TransmitFile("news",id,contactId);
            }
            else
            {
                await windowsServiceRequests.TransmitFile("photo", id, contactId);
            }

            return RedirectToAction("index", "Home");
        }


    }
}
