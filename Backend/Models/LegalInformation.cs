using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Chatty.Models
{
    public class LegalInformation : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonalIdentificationNumber { get; set; }

        public string CardNumber{get;set;}
        public string Address{get;set;}

        public User User{get; set;}


    }
}
