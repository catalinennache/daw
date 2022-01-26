using Chatty.Models;
using Chatty.Core;
using System.Linq;
namespace Chatty.Data {

    public class UserRepository: GenericRepository<User>, IUserRepository{

        public UserRepository(ApplicationContext ctx): base(ctx){
        }

        public User GetByEmail(string Email){
          return _context.Users.Where(x=>x.Email == Email).FirstOrDefault();
        }
    }
}