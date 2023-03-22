using FileworxObjects.DTOs;
using FileworxObjects.Objects;
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
        public static GridViewRows DtoToGridViewRows(ContactDTO dto)
        {
            GridViewRows rows = new GridViewRows
            {
                Created = dto.Created,
                Name = dto.Name,
                Description = dto.Description,
                ID = dto.ID,
                ClassId = dto.ClassID
            };
            return rows;
        }
    }
}
