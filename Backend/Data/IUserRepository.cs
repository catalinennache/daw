using Chatty.Models;

namespace Chatty.Data {

    public interface IUserRepository{
        User GetByEmail(string Email);
    }
}