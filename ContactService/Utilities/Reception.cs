using FileworxObjects.DTOs;
using FileworxObjects.Objects.Contact;
using FileworxObjects;
using FileworxObjects.Mappers;

namespace WorkerService1.Utilities
{
    public class Reception
    {
        public static readonly string SharedFolder = "D:\\SharedPhotos";
        public static async Task CheckAndSaveNew(ApiRequests apiRequests, Contact contact)
        {
            List<string> names = FileOperations.IsUpToDate(contact.ReceivePath, contact.LastReceptionDate);
            if (names.Count > 0)
            {
                await SaveUpdatedFiles(apiRequests, contact, names);
                await UpdateReceptionDate(apiRequests, contact);
            }
        }

        private static async Task UpdateReceptionDate(ApiRequests apiRequests, Contact contact)
        {
            contact.LastReceptionDate = DateTime.Now;
            ContactDTO updatedContact = ContactMapper.ContactToDto(contact);
            await apiRequests.Update("Contact", updatedContact);
        }

        private static async Task SaveUpdatedFiles(ApiRequests apiRequests, Contact contact, List<string> names)
        {
            foreach (string name in names)
            {
                string path = Path.Combine(contact.ReceivePath, name);
                string content = FileOperations.ReadFile(path);
                bool isNews = CheckIfIsNews(content);

                if (isNews)
                {
                    await SaveNews(apiRequests, contact, content);
                }
                else
                {
                    await SavePhoto(apiRequests, contact, content);
                }
            }
        }

        private static async Task SavePhoto(ApiRequests apiRequests, Contact contact, string content)
        {
            PhotoDTO photoDTO = ServiceMapper.FileContentToPhoto(content);
            photoDTO.ContactId = contact.ID;
            photoDTO.ImagePath = FileOperations.CopyPhoto(SharedFolder, photoDTO.ImagePath);
            await apiRequests.Create("Photo", photoDTO);
        }

        private static async Task SaveNews(ApiRequests apiRequests, Contact contact, string content)
        {
            NewsDTO newsDTO = ServiceMapper.FileContentToNews(content);
            newsDTO.ContactId = contact.ID;
            await apiRequests.Create("News", newsDTO);
        }

        private static bool CheckIfIsNews(string content)
        {
            string[] arr = content.Split("%");
            return int.Parse(arr[10]) == 1;
        }
    }
}
