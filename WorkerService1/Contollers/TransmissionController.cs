using FileworxObjects;
using FileworxObjects.Objects;
using FileworxObjects.Objects.Contact;
using Microsoft.AspNetCore.Mvc;
using WorkerService1.Utilities;

namespace WorkerService1.Contollers
{
    public class TransmissionController : Controller
    {
        readonly ApiRequests apiRequests = new();

        [HttpGet("/News/{newsId}/{contactId}")]
        public async Task<string> SaveNews(int newsId,int contactId)
        {
            News newsToSave = await apiRequests.GetByID<News>("news", newsId);
            Contact contact = await apiRequests.GetByID<Contact>("contact", contactId);
            FileOperations.WriteToFile(contact.SendPath, newsToSave.ToString());
            return "success";
        }

        [HttpGet("/Photo/{photoId}/{contactId}")]
        public async Task<string> SavePhoto(int photoId, int contactId)
        {
            Photo photoToSave = await apiRequests.GetByID<Photo>("photos", photoId);
            Contact contact = await apiRequests.GetByID<Contact>("contact", contactId);
            FileOperations.WriteToFile(contact.SendPath, photoToSave.ToString());
            return "success";
        }
    }
}
