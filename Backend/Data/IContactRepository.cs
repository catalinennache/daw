using Chatty.Models;

namespace Chatty.Data {

    public interface IContactRepository{
        void AddContact(Contact user);
    }
}