using Microsoft.AspNetCore.Mvc;
using Chatty.Core;
using System;
using Chatty.Models.DTOs;
using Chatty.Models;
using System.Collections;
using Microsoft.AspNetCore.Http;
namespace Chatty.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    class ContactController : Controller
    {
        UnitOfWork unitOfWork;
        public ContactController(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        [HttpPost("{userId}")]
        public IActionResult Get(Guid userId)
        {
            var contacts = unitOfWork.GetContactRepository().GetByUserId(userId);
            return Ok(contacts);
        }

        [HttpPost("add")]
        public IActionResult Add(ContactDTO contactDTO)
        {
            var owner = unitOfWork.GetUserRepository().FindById(contactDTO.Owner);

            var contact = new Contact()
            {
                NickName = contactDTO.NickName,
                Owner = owner,
                User = contactDTO.User
            };

            unitOfWork.GetContactRepository().Create(contact);
            unitOfWork.Save();

            return Ok(contact.Id);
        }


        [HttpPost("update")]
        public IActionResult Update(ContactDTO contactDTO)
        {
            var contact = unitOfWork.GetContactRepository().FindById(contactDTO.Id);

            contact.NickName = contactDTO.NickName;

            unitOfWork.GetContactRepository().Update(contact);

            return Ok(unitOfWork.Save());
        }

        [HttpPost("delete")]
        public IActionResult Delete(Guid contactId)
        {
            var contact = unitOfWork.GetContactRepository().FindById(contactId);
            unitOfWork.GetContactRepository().Delete(contact);

            return Ok(unitOfWork.Save());
        }

    }
}