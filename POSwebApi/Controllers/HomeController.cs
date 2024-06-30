using Microsoft.AspNetCore.Mvc;

namespace POSwebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
       

        [HttpGet(Name = "GetHome")]

        public User Get()
        {
            return new User { name = "qasim" };
        }
       
    }
}
