﻿using Microsoft.AspNetCore.Mvc;
using FileworxObjects.Mappers;
using FileworxObjects.Objects;
using FileworxObjects.DTOs;

namespace FileworxAPI.Controllers
{
    public class UserController : Controller
    {
        [HttpPost("/login")]
        public int ValidateLogin([FromBody]LoginCredentials login)
        {
            User newUser = new()
            {
                LoginName = login.userName,
                Password = login.password
            };

            if(newUser.Validate())
            {
               return newUser.GetID();
            }

            return -1;
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
            user.ClassID = 3;
            user.ID = -1;
            if (!user.UserExists())
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
