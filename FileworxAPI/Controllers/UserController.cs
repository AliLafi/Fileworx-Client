using FileworxObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;

namespace FileworxAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("/login")]
        public bool ValidateLogin([FromBody]LoginCredentials login)
        {
            User u = new User();
            u.LoginName = login.userName; 
            u.Password = login.password;
            

            return u.Validate();

        }

        [HttpDelete("/User")]
        public string DeleteUser([FromBody] UserDTO dto)
        {
            User user = UserMapper.DtoToUser(dto);
            user.Delete();
            return "Deleted Successfully";
        }

        [HttpPost("/User")]
        public string AddUser([FromBody] UserDTO dto)
        {
            User user = UserMapper.DtoToUser(dto);

            if (user.UserExists())
            {

                user.Update();
                return "Added Successfully";

            }
            return "User Exists";
        }

        [HttpPut("/User")]
        public string UpdateUser([FromBody] UserDTO dto)
        {
            User user = UserMapper.DtoToUser(dto);
            user.Update();
            return "Updated Successfully";
        }

    }

}
