using System.Collections.Generic;
namespace Chatty.Models
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password {get; set;}

        public IEnumerable<Contact> Contacts;
        public IEnumerable<Message> Messages;

    }
}
