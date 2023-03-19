using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using FileworxObjects.Objects.Contact;
using Microsoft.AspNetCore.Mvc;

namespace FileworxAPI.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet("Contact/{id}")]
        public JsonResult GetContactByID(int id)
        {
            Contact contact= new()
            {
                ID = id
            };

            contact= contact.Read();
            return Json(contact);
        }
        [HttpGet("/Contacts")]
        public List<Contact> GetContacts()
        {
            Contact contact = new();

            return contact.Run();
        }

        [HttpGet("/Contacts/send")]
        public List<Contact> GetSendContacts()
        {
            Contact contact = new();

            return contact.SendContacts();
        }

        [HttpGet("/Contacts/receive")]
        public List<Contact> GetReceiveContacts()
        {
            Contact contact = new();
            
            return contact.ReceiveContacts();
        }


        [HttpPost("/Contact")]
        public string AddContact([FromBody] ContactDTO dto)
        {

            Contact contactToAdd = ContactMapper.DTOToContact(dto);
            contactToAdd.ID = -1;
            contactToAdd.ClassID = 4;
            contactToAdd.LastReceptionDate= DateTime.Now;
            contactToAdd.ModifyDate = DateTime.Now;
            contactToAdd.Created = DateTime.Now;
            contactToAdd.Update();
            return "Added Successfully";
        }

        [HttpPut("/Contact")]
        public string UpdateContact([FromBody] ContactDTO dto)
        {
            Contact contactToUpdate = ContactMapper.DTOToContact(dto);
            contactToUpdate.ClassID= 4;
            contactToUpdate.ModifyDate = DateTime.Now;
            contactToUpdate.Update();
            return "Updated Successfully";
        }

        [HttpDelete("/Contact/{id}")]
        public string DeleteContact(int id )
        {
            Contact contactToDelete = new()
            {
                ID = id
            };
            contactToDelete.Delete();
            return "Deleted Successfully";
        }

    }
}
