using FileworxObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using FileworxObjects.DTOs;
using FileworxObjects.Mappers;

namespace FileworxAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/Users")]
        public Hashtable GetUsers()
        {


            UsersQuery UserQuery = new UsersQuery();
            Hashtable h= UserQuery.ReadLoginInfo();
            return h;

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
            user.Update();
            return "Added Successfully";
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
