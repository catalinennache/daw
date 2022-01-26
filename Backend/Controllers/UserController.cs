using Microsoft.AspNetCore.Mvc;
using Chatty.Core;
using System.Threading.Tasks;

namespace Chatty.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    class UserController : Controller
    {
        UnitOfWork unitOfWork;
        public UserController(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await unitOfWork.GetUserRepository().GetAll());
        }
       
    }
}