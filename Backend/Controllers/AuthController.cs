using Microsoft.AspNetCore.Mvc;
using Chatty.Data;
namespace Chatty.Controllers
{


    [Route("")]
    [ApiController]
    class AuthController : Controller
    {   
        IUserRepository userRepo;
        public AuthController(IUserRepository _userRepo){
            userRepo = _userRepo;
        }
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok();
        }
    }
}