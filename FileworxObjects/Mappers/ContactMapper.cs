using FileworxObjects.DTOs;
using FileworxObjects.Objects;
using FileworxObjects.Objects.Contact;

namespace FileworxObjects.Mappers
{
    public class ContactMapper
    {
        public static ContactDTO ContactToDto(Contact contact)
        {
            return new ContactDTO(contact.IsReadFile, contact.IsWriteFile, contact.SendFilePath, contact.ReceiveFilePath, contact.LastFileReceptionDate, contact.IsWriteFtp, contact.IsReadFtp, contact.SendFtpPath, contact.ReceiveFtpPath, contact.LastFtpReceptionDate,contact.Host,contact.Username,contact.Password, contact.IsWriteTelegram, contact.TelegramUsername, contact.ID, contact.LastModifier, contact.Creator, contact.Name, contact.Description, contact.Created, contact.ModifyDate);
        }
        public static Contact DTOToContact(ContactDTO dto)
        {
            return new Contact(dto.IsReadFile, dto.IsWriteFile, dto.SendFilePath, dto.ReceiveFilePath, dto.LastFileReceptionDate, dto.IsWriteFtp, dto.IsReadFtp, dto.SendFtpPath, dto.ReceiveFtpPath, dto.LastFtpReceptionDate,dto.Host,dto.Username,dto.Password, dto.IsWriteTelegram, dto.TelegramUsername,  dto.ID, dto.LastModifier, dto.Creator, dto.Name, dto.Description, dto.Created, dto.ModifyDate);
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
