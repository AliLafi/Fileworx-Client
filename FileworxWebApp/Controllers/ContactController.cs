using Fileworx_Client;
using FileworxObjects.DTOs;
using FileworxObjects.Objects.Contact;
using FileworxWebApp.Mappers;
using FileworxWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileworxWebApp.Controllers
{
    public class ContactController : Controller
    {
        ApiRequests req = new ApiRequests();
        public async Task<ActionResult> Index()
        {

            List<ContactModel> contacts = await req.GetAll<ContactModel>("contacts");
            return View(contacts);
        }

        public async Task <ActionResult> Details(int id)
        {
            ContactModel contact = await req.GetByID<ContactModel>("contact", id);
            return View(contact);
        }

        public ActionResult Create()
        {
            ViewBag.Modifier = HttpContext.Session.GetInt32("modifier");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactModel contact)
        {

            if (ModelState.IsValid)
            {
                ContactDTO contactToSave = ContactMapper.ContactToDto(contact);
                await req.Create("contact", contactToSave);
            }

              return RedirectToAction("index","Contact");    
        }

        public async Task<ActionResult> Edit(int id)
        {
            ContactModel contact = await req.GetByID<ContactModel>("contact", id);
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContactModel contact)
        {
            if(!contact.IsWrite)
            {
                contact.SendPath = "";   
            }
            if(!contact.IsRead)
            {
                contact.ReceivePath = "";
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
