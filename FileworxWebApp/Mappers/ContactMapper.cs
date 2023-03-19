using FileworxObjects.DTOs;
using FileworxWebApp.Models;

namespace FileworxWebApp.Mappers
{
    public class ContactMapper
    {
        public static ContactDTO ContactToDto(ContactModel model)
        {
            return new ContactDTO(model.IsRead,model.IsWrite, model.SendPath, model.ReceivePath, model.LastReceptionDate, model.ID, model.LastModifier, model.Creator, model.Name, model.Description, model.Created, model.LastModified);
        }
    }
}
