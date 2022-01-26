using Microsoft.AspNetCore.Mvc;
using Chatty.Core;
using System;
using Chatty.Models.DTOs;
using Chatty.Models;
namespace Chatty.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    class MessageController : Controller
    {
        UnitOfWork unitOfWork;
        public MessageController(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        [HttpPost("{contactId}")]
        public IActionResult Get(Guid contactId)
        {
            var messages = unitOfWork.GetMessageRepository().GetByContactId(contactId);
            return Ok(messages);
        }

        [HttpPost("add")]
        public IActionResult Add(MessageDTO messageDTO)
        {   
            var contact = unitOfWork.GetContactRepository().FindById(messageDTO.ContactId);

            var message = new Message(){
                MessageContent = messageDTO.Message,
                Contact = contact,
                UnixTimestamp = messageDTO.UnixTimestamp
            };
            
            unitOfWork.GetMessageRepository().Create(message);
            unitOfWork.Save();
            
            return Ok(message.Id);
        }

        
        [HttpPost("update")]
        public IActionResult Update(MessageDTO messageDTO)
        {   
            var message = unitOfWork.GetMessageRepository().FindById(messageDTO.Id);

            message.MessageContent = messageDTO.Message;
            message.UnixTimestamp = messageDTO.UnixTimestamp;
            
            unitOfWork.GetMessageRepository().Update(message);
            
            return Ok(unitOfWork.Save());
        }

        [HttpPost("delete")]
        public IActionResult Delete(Guid messageId)
        {   
            var message = unitOfWork.GetMessageRepository().FindById(messageId);            
            unitOfWork.GetMessageRepository().Delete(message);
            
            return Ok(unitOfWork.Save());
        }

    }
}