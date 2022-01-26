using Microsoft.AspNetCore.Mvc;
using Chatty.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace Chatty.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    class UserController : ControllerBase
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