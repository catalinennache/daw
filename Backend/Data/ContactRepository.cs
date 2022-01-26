using Chatty.Models;
using Chatty.Core;
using System.Linq;
using System.Collections.Generic;
using System;
namespace Chatty.Data
{

    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        //void AddContact(Contact user);
        public ContactRepository(ApplicationContext ctx) : base(ctx)
        {

        }

        public IEnumerable<Contact> GetByUserId(Guid id)
        {
            return _context.Contacts.Where(x => x.Owner.Id == id);
        }

    }
}