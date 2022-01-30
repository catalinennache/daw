using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Chatty.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public IEnumerable<Contact> Contacts {get; set;}

        public LegalInformation LegalInformation {get;set;}


    }
}
