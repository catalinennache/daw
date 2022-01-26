using Chatty.Models;
using System.Collections.Generic;
using System;
namespace Chatty.Data {

    public interface IMessageRepository{
        public IEnumerable<Message> GetByContactId(Guid id);

    }
}