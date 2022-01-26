using Chatty.Models;
using Chatty.Core;
namespace Chatty.Data {

    public class  MessageRepository : GenericRepository<Message>, IMessageRepository{
        //void AddContact(Contact user);
        public MessageRepository(ApplicationContext ctx):base(ctx){
            
        }
    }
}