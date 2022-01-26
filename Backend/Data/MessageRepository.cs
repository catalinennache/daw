using Chatty.Models;
using Chatty.Core;
using System.Linq;
using System.Collections.Generic;
using System;
namespace Chatty.Data {

    public class  MessageRepository : GenericRepository<Message>, IMessageRepository{
        //void AddContact(Contact user);
        public MessageRepository(ApplicationContext ctx):base(ctx){
            
        }

        
        public IEnumerable<Message> GetByContactId(Guid id)
        {
            return _context.Messages.Where(x => x.Contact.Id == id);
        }

    }
}