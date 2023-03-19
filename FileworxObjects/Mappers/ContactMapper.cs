using FileworxObjects.DTOs;
using FileworxObjects.Objects.Contact;

namespace FileworxObjects.Mappers
{
    public class ContactMapper
    {
        public static ContactDTO ContactToDto(Contact contact)
        {
            return new ContactDTO(contact.IsRead,contact.IsWrite,contact.SendPath,contact.ReceivePath,contact.LastReceptionDate, contact.ID,contact.LastModifier, contact.Creator, contact.Name, contact.Description, contact.Created, contact.ModifyDate);
        }
        public static Contact DTOToContact(ContactDTO dto)
        {
            return new Contact(dto.IsRead, dto.IsWrite, dto.SendPath, dto.ReceivePath,dto.LastReceptionDate, dto.ID, dto.LastModifier, dto.Creator, dto.Name, dto.Description, dto.Created, dto.ModifyDate);
        }
    }
}
