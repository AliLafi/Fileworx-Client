using FileworxObjects.DTOs;
using FileworxWebApp.Models;

namespace FileworxWebApp.Mappers
{
    public class ContactMapper
    {
        public static ContactDTO ContactToDto(ContactModel model)
        {
            return new ContactDTO(model.IsReadFile,model.IsWriteFile, model.SendFilePath, model.ReceiveFilePath, model.LastFileReceptionDate,model.IsWriteFtp,model.IsReadFtp,model.SendFtpPath,model.ReceiveFtpPath,model.LastFtpReceptionDate,model.Host,model.Username,model.Password,model.IsWriteTelegram, model.TelegramUsername, model.ID, model.LastModifier, model.Creator, model.Name, model.Description, model.Created, model.LastModified);
        }
    }
}
