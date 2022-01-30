using Microsoft.AspNetCore.Mvc;
using Chatty.Core;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Chatty.Models;
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
            IEnumerable<User> users = await unitOfWork.GetUserRepository().GetAll();
            IEnumerable<LegalInformation> legalInfos = await unitOfWork.GetLegalInformationRepository().GetAll();
            var result = users.Join(legalInfos, (User x) => x.LegalInformation.Id, (LegalInformation y) => y.Id, (student, standard) => new  // result selector
            {
                StudentName = student.Email,
                StandardName = standard.FirstName
            });
            return Ok(await unitOfWork.GetUserRepository().GetAll());
        }

    }
}