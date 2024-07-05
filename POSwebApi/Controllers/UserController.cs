using Microsoft.AspNetCore.Mvc;
using posApp.Models;
using POSwebApi.Dtos;
using POSwebApi.DtoConveters;
using posApp.Service;



namespace POSwebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _userService;
        public UserController(IService<User> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            List<UserDTO> usersDTO = UserConverter.ToDTOList(users);
            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            UserDTO userDTO = UserConverter.ToDTO(user);
            return Ok(userDTO);
        }

        /* [HttpGet("authenticate/{email}")]
         public ActionResult<bool> Authenticate(string email, string password)
         {
             User? user = _userService.AuthenticateUser(email, password);
             if (user != null)
             {
                 return Ok(true);
             }
             return Ok(false);
         }*/

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            await _userService.AddAsync(user);
            UserDTO userDTO = UserConverter.ToDTO(user);
            return CreatedAtAction(nameof(GetById), new { id = user.id }, userDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the user
            await _userService.UpdateAsync(user);
            UserDTO userDTO = UserConverter.ToDTO(user);
            return Ok(userDTO);
        }

        /* [HttpPatch("updateUserRole")]
     public ActionResult<UserDTO> UpdateUserRole(string email, string role)
     {
         User? existingUser = _userService.FindUser(email);
         if (existingUser == null)
         {
             return NotFound(new { messgae = "User not found" });
         }

         User? updatedUser = _userService.UpdateUserRole(email, role);
         return Ok(UserConverter.ToDTO(updatedUser));
     }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)

        {

            var product = await _userService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(id);
            return Ok();
        }

    }
}
