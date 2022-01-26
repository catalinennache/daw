
using System;
using System.Threading.Tasks;
using Chatty.Data;

namespace Chatty.Core
{
    public interface IUnitOfWork
    {
        public UserRepository GetUserRepository();
        public ContactRepository GetContactRepository();
        public MessageRepository GetMessageRepository();

        public bool Save();
        public Task<bool> SaveAsync();

    }
}