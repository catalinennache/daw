using Chatty.Models;

namespace Chatty.Data {

    public interface IUserRepository{
        void Create(User user);
    }
}