using Chatty.Models;
using System.Collections.Generic;
using System;
namespace Chatty.Data {

    public interface IContactRepository{
            public IEnumerable<Contact> GetByUserId(Guid id);

    }
}