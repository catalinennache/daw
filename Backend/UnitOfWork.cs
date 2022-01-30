
using System;
using System.Threading.Tasks;
using Chatty.Data;

namespace Chatty.Core
{
    public class UnitOfWork : IUnitOfWork
    {

        ApplicationContext _context;
        UserRepository _userRepo;
        ContactRepository _contactRepo;
        MessageRepository _messageRepo;
        LegalInformationRepository _legalInfoRepo;

        public UnitOfWork(ApplicationContext context, UserRepository userRepo, LegalInformationRepository legalInfoRepo, ContactRepository contactRepo, MessageRepository messageRepo)
        {
            _context = context;
            _userRepo = userRepo;
            _contactRepo = contactRepo;
            _messageRepo = messageRepo;
            _legalInfoRepo = legalInfoRepo;
        }

        public UserRepository GetUserRepository() { return _userRepo; }
        public ContactRepository GetContactRepository() { return _contactRepo; }
        public MessageRepository GetMessageRepository() { return _messageRepo; }

        public LegalInformationRepository GetLegalInformationRepository() { return _legalInfoRepo; }



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