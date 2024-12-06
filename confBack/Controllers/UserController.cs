using confBack.Dto;
using confBack.Models;
using confBack.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace confBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _userInterface;

        public UserController(UserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet("ToListUsers")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> ToListUsers()
        {
            var users = await _userInterface.ToListUsers();
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> CreateUser(CreateUserDto createUserDto)
        {
            var users = await _userInterface.CreateUser(createUserDto);
            return Ok(users);
        }

        [HttpPut("EditUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> EditUser(EditUserDto editUserDto)
        {
            var users = await _userInterface.EditUser(editUserDto);
            return Ok(users);
        }

        [HttpDelete("RemoveUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> RemoveUser(int idUser)
        {
            var users = await _userInterface.RemoveUser(idUser);
            return Ok(users);
        }




    }
}
