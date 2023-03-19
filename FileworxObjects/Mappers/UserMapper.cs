using FileworxObjects.DTOs;
using FileworxObjects.Objects;

namespace FileworxObjects.Mappers
{
    public class UserMapper
    {
        public static User DtoToUser(UserDTO dto)
        {
            if (dto.ID == -1)
            {
                return new User(dto.LoginName, dto.Password, dto.LastModifier, dto.Creator, dto.Name, dto.Description, dto.Created, dto.ModifyDate);
            }
            else
            {
                return new User(dto.LoginName, dto.Password, dto.ID,dto.LastModifier, dto.Creator, dto.Name, dto.Description, dto.Created, dto.ModifyDate);
            }
        }

        public static UserDTO UserToDto(User user)
        {
            if (user.ID == -1)
            {
                return new UserDTO(user.LoginName, user.Password, user.LastModifier, user.Creator, user.Name, user.Description, user.Created, user.ModifyDate);
            }
            else
            {
                return new UserDTO(user.LoginName, user.Password, user.ID, user.LastModifier, user.Creator, user.Name, user.Description, user.Created, user.ModifyDate);
            }
        }
    }
}
