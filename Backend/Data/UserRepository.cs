using Chatty.Models;
using Chatty.Core;
namespace Chatty.Data {

    public class UserRepository: GenericRepository<User>, IUserRepository{

        public UserRepository(ApplicationContext ctx): base(ctx){

        }
    }
}