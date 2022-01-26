using System;

namespace Chatty.Models
{
    public class Message:BaseEntity
    {
        public Contact Contact { get; set; }
        public string MessageContent {get; set;}
        public long UnixTimestamp {get; set;}
    }

}