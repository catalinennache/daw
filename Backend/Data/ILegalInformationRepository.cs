using Chatty.Models;

namespace Chatty.Data {

    public interface ILegalInformationRepository{
        LegalInformation GetByUser(User user);
    }
}