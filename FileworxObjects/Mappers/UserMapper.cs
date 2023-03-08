using FileworxObjects.DTOs;

namespace FileworxObjects.Mappers
{
    public class UserMapper
    {
        public static User DtoToUser(UserDTO dto)
        {
            if (dto.ID == -1)
            {
                return new User(dto.Name, dto.Description, dto.Created, dto.ClassID, dto.LoginName, dto.Password, dto.LastModifier);
            }
            else
            {
                return new User(dto.Name, dto.Description, dto.Created, dto.ID, dto.ClassID, dto.LoginName, dto.Password, dto.LastModifier);          
            }
        }

        public static UserDTO UserToDto(User user)
        {
            if (user.ID == -1)
            {
                return new UserDTO(user.Name, user.Description, user.Created, user.ClassID, user.LoginName, user.Password, user.LastModifier);
            }
            else
            {
                return new UserDTO(user.Name, user.Description, user.Created, user.ID,  user.LoginName, user.Password, user.LastModifier);
            }
        }
    }
}
