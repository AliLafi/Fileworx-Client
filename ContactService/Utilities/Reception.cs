using FileworxObjects.DTOs;
using FileworxObjects.Objects.Contact;
using FileworxObjects;
using FileworxObjects.Mappers;
using ContactService.Utilities;
using FluentFTP;

namespace WorkerService1.Utilities
{
    public class Reception
    {
        public static readonly string SharedFolder = "D:\\SharedPhotos";
        public static async Task CheckAndSaveNew(ApiRequests apiRequests, Contact contact)
        {
            if (contact.IsReadFile)
            {

                List<string> names = FileOperations.IsUpToDate(contact.ReceiveFilePath, contact.LastFileReceptionDate);
                if (names.Count > 0)
                {
                    await SaveUpdatedFiles(apiRequests, contact, names);
                    await UpdateReceptionDate(apiRequests, contact);
                }
            }

            if (contact.IsReadFtp)
            {
                FtpClient client = new FtpClient(contact.Host, contact.Username, contact.Password); ;
                List<string> names = FtpOperations.IsUpToDateFtp(client, contact.ReceiveFtpPath, contact.LastFtpReceptionDate);
                if (names.Count > 0)
                {
                    await SaveUpdatedFilesFtp(client, apiRequests, contact, names);
                    await UpdateReceptionDateFtp(apiRequests, contact);
                }
            }
        }

        private static async Task UpdateReceptionDate(ApiRequests apiRequests, Contact contact)
        {
            contact.LastFileReceptionDate = DateTime.Now;
            ContactDTO updatedContact = ContactMapper.ContactToDto(contact);
            await apiRequests.Update("Contact", updatedContact);
        }
        private static async Task UpdateReceptionDateFtp(ApiRequests apiRequests, Contact contact)
        {
            contact.LastFtpReceptionDate = DateTime.Now;
            ContactDTO updatedContact = ContactMapper.ContactToDto(contact);
            await apiRequests.Update("Contact", updatedContact);
        }

        private static async Task SaveUpdatedFiles(ApiRequests apiRequests, Contact contact, List<string> names)
        {
            foreach (string name in names)
            {
                string path = Path.Combine(contact.ReceiveFilePath, name);
                string content = FileOperations.ReadFile(path);
                
                await WriteToFile(apiRequests, contact, content);
            }
        }

        private static async Task SaveUpdatedFilesFtp(FtpClient client,ApiRequests apiRequests, Contact contact, List<string> names)
        {
            foreach (string name in names)
            {
                string tempfile = Path.Combine(Path.GetTempPath(),Guid.NewGuid().ToString());
                string fileToDownload = Path.Combine(contact.ReceiveFtpPath, name);
                client.DownloadFile(tempfile, fileToDownload, FtpLocalExists.Overwrite);

                string content = FileOperations.ReadFile(tempfile);
                await WriteToFile(apiRequests, contact, content);
                
                System.IO.File.Delete(tempfile);
            }
        }

        private static async Task WriteToFile(ApiRequests apiRequests, Contact contact, string content)
        {
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