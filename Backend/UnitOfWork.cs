
using System;
using System.Threading.Tasks;
using Chatty.Data;

namespace Chatty.Core
{
    public class UnitOfWork : IUnitOfWork
    {

        ApplicationContext _context;
        IUserRepository _userRepo;
        IUserRepository _contactsRepo;
        IUserRepository _messageRepo;

        public UnitOfWork(ApplicationContext context, IUserRepository userRepo){
            _context = context;
            _userRepo = userRepo;
        }

        // Save
        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

    }
}