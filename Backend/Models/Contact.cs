using System;
using System.Collections.Generic;

namespace Chatty.Models
{
    public class Contact:BaseEntity
    {   
        public string NickName {get; set;}
        public User Owner {get; set;}
        public Guid User {get; set;}

        public ICollection<Message> Messages {get; set;} 
    }

}