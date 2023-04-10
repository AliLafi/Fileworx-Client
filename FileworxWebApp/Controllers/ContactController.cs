using FileworxObjects;
using FileworxObjects.DTOs;
using FileworxWebApp.Mappers;
using FileworxWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileworxWebApp.Controllers
{
    public class ContactController : Controller
    {
        readonly ApiRequests req = new();
         
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
            List<ContactModel> contacts = await req.GetAll<ContactModel>("contacts");
            return View(contacts);
        }

        public async Task<ActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
            ContactModel contact = await req.GetByID<ContactModel>("contact", id);
            return View(contact);
        }

        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
            ViewBag.Modifier = HttpContext.Session.GetInt32("modifier");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactModel contact)
        {
            if (!contact.IsWriteFile)
            {
                contact.SendFilePath = "";
            }
            if (!contact.IsReadFile)
            {
                contact.ReceiveFilePath = "";
            }
            if (!contact.IsWriteFtp)
            {
                contact.SendFtpPath = "";
            }
            if (!contact.IsReadFtp)
            {
                contact.ReceiveFtpPath = "";
            }
            if (!contact.IsReadFtp && !contact.IsWriteFtp)
            {
                contact.Host = "";
                contact.Username = "";
                contact.Password = "";
            }
            if (ModelState.IsValid)
            {
                ContactDTO contactToSave = ContactMapper.ContactToDto(contact);
                await req.Create("contact", contactToSave);
            }

            return RedirectToAction("index", "Contact");
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("loggedIn") != "in")
            {
                return RedirectToAction("login", "home");
            }
            ContactModel contact = await req.GetByID<ContactModel>("contact", id);
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContactModel contact)
        {
            if (!contact.IsWriteFile)
            {
                contact.SendFilePath = "";
            }
            if (!contact.IsReadFile)
            {
                contact.ReceiveFilePath = "";
            }
            if(!contact.IsWriteFtp)
            {
                contact.SendFtpPath = "";
            }
            if (!contact.IsReadFtp)
            {
                contact.ReceiveFtpPath = "";
            }
            if(!contact.IsReadFtp && !contact.IsWriteFtp)
            {
                contact.Host = "";
                contact.Username = "";
                contact.Password = "";
            }
            if (ModelState.IsValid)
            {
                ContactDTO contactDTO = ContactMapper.ContactToDto(contact);
                await req.Update("Contact", contactDTO);
            }

            return RedirectToAction("Index", "Contact");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await req.Delete("Contact", id);
            return RedirectToAction("Index", "Contact");
        }       
    }
}
