using Microsoft.AspNetCore.Mvc;
using posApp.Models;
using POSwebApi.Dtos;
using POSwebApi.DtoConveters;
using posApp.Services;



namespace POSwebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userManager)
        {
            _userService = userManager;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            List<User> allUsers = _userService.GetUsers();
            return Ok(UserConverter.ToDTOList(allUsers));

        }

        [HttpGet("{email}")]
        public ActionResult<UserDTO> GetUser(string email)
        {
            User? user = _userService.FindUser(email);
            if (user == null)
            {
                return NotFound(new { messgae = "User not found" });
            }
            return Ok(UserConverter.ToDTO(user));
        }

        [HttpGet("authenticate/{email}")]
        public ActionResult<bool> Authenticate(string email, string password)
        {
            User? user = _userService.AuthenticateUser(email, password);
            if (user != null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        public ActionResult<IEnumerable<UserDTO>> CreateUser(User user)
        {
            User? existingUser = _userService.FindUser(user.email);

            if (existingUser != null)
            {
                return Conflict(new { message = "User already exist" });

            }
            _userService.AddUser(user);
            UserDTO userDTO = UserConverter.ToDTO(user);
            return CreatedAtAction(nameof(GetUser), new { email = user.email }, userDTO);
        }

        [HttpPatch("updateUserRole")]
        public ActionResult<UserDTO> UpdateUserRole(string email, string role)
        {
            User? existingUser = _userService.FindUser(email);
            if (existingUser == null)
            {
                return NotFound(new { messgae = "User not found" });
            }

            User? updatedUser = _userService.UpdateUserRole(email, role);
            return Ok(UserConverter.ToDTO(updatedUser));
        }

        [HttpDelete("{email}")]
        public ActionResult DeleteUser(string email)
        {
            User? existingUser = _userService.FindUser(email);

            if (existingUser == null)
            {
                return NotFound(new { message = "User not found" });
            }
            _userService.DeleteUser(email);
            return Ok(new { message = "User deleted successfully" });
        }

    }
}
