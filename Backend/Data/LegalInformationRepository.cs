using Chatty.Models;
using Chatty.Core;
using System.Linq;
namespace Chatty.Data {

    public class LegalInformationRepository: GenericRepository<LegalInformation>, ILegalInformationRepository{

        public LegalInformationRepository(ApplicationContext ctx): base(ctx){
        }

        public LegalInformation GetByUser(User user){
          return _context.LegalInformation.Where(x=>x.User == user).FirstOrDefault();
        }
    }
}