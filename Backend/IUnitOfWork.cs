
using System;
using System.Threading.Tasks;
using Chatty.Data;

namespace Chatty.Core
{
    public interface IUnitOfWork
    {
        public bool Save();
        public Task<bool> SaveAsync();

    }
}