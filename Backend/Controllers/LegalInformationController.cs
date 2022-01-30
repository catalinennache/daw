using Microsoft.AspNetCore.Mvc;
using Chatty.Core;
using System;
using Chatty.Models.DTOs;
using Chatty.Models;
namespace Chatty.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    class LegalInformationController : Controller
    {
        UnitOfWork unitOfWork;
        public LegalInformationController(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }




        [HttpPost("add")]
        public IActionResult Add(LegalInformationDTO legalInfoDTO)
        {   var user = unitOfWork.GetUserRepository().FindById(legalInfoDTO.User);
            var legalInfo = unitOfWork.GetLegalInformationRepository().GetByUser(user);

            if(legalInfo != null){
                Ok(false);
            }
            

            unitOfWork.GetLegalInformationRepository().Create(new LegalInformation(){
                FirstName = legalInfo.FirstName,
                LastName = legalInfo.LastName,
                MiddleName = legalInfo.MiddleName,
                PersonalIdentificationNumber = legalInfo.PersonalIdentificationNumber,
                User = user
            });
            unitOfWork.Save();
            
            
            return Ok(true);
        }

        
        [HttpPost("update")]
        public IActionResult Update(LegalInformationDTO legalInfo)
        {   
            var legalInformation = unitOfWork.GetLegalInformationRepository().FindById(legalInfo.Id);

            legalInformation.Address = legalInfo.Address;
            legalInformation.FirstName = legalInfo.FirstName;
            legalInformation.MiddleName = legalInfo.MiddleName;
            legalInformation.LastName = legalInfo.LastName;
            legalInformation.PersonalIdentificationNumber = legalInfo.PersonalIdentificationNumber;

            unitOfWork.GetLegalInformationRepository().Update(legalInformation);
            
            return Ok(unitOfWork.Save());
        }

        [HttpPost("delete")]
        public IActionResult Delete(Guid userId)
        {   
            var user = unitOfWork.GetUserRepository().FindById(userId);
            var legalInformation = unitOfWork.GetLegalInformationRepository().GetByUser(user);            

            unitOfWork.GetLegalInformationRepository().Delete(legalInformation);
            
            return Ok(unitOfWork.Save());
        }

    }
}