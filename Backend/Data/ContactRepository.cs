using Chatty.Models;
using Chatty.Core;
namespace Chatty.Data {

    public class ContactRepository : GenericRepository<Contact>, IContactRepository{
        //void AddContact(Contact user);
        public ContactRepository(ApplicationContext ctx): base(ctx){

        }

    }
}