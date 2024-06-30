﻿using Microsoft.AspNetCore.Mvc;
using posApp;


namespace POSwebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;
        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }   

        [HttpGet("all")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            List<User> allUsers = _userManager.GetUsers();
            return Ok(allUsers);

        }

        [HttpGet("{email}")]
        public ActionResult<User> GetUser(string email)
        {
            User? user = _userManager.FindUser(email);
            if (user == null)
            {
                return NotFound(new { messgae = "User not found" });
            }
            return Ok(user);
        }

        [HttpGet("authenticate/{email}")]
        public ActionResult<bool> Authenticate(string email, string password)
        {
            User? user = _userManager.AuthenticateUser(email, password);
            if (user != null)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        public ActionResult<IEnumerable<User>> CreateUser(User user)
        {
            User? existingUser = _userManager.FindUser(user.email);

            if (existingUser != null)
            {
                return Conflict(new { message = "User already exist" });

            }
            _userManager.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { email = user.email }, user);
        }

        [HttpPatch("updateUserRole")]
        public ActionResult<User> UpdateUserRole(string email, string role)
        {
            User? existingUser = _userManager.FindUser(email);
            if (existingUser == null)
            {
                return NotFound(new { messgae = "User not found" });
            }

            User? updatedUser = _userManager.UpdateUserRole(email, role);
            return Ok(updatedUser);
        }

        [HttpDelete("{email}")]
        public ActionResult DeleteUser(string email)
        {
            User? existingUser = _userManager.FindUser(email);

            if (existingUser == null)
            {
                return NotFound(new { message = "User not found" });
            }
            _userManager.DeleteUser(email);
            return Ok(new { message = "User deleted successfully" });
        }

    }
}
