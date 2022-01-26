using System.ComponentModel.DataAnnotations;
using System;
namespace Chatty.Models.DTOs
{
    public class MessageDTO
    {
        public Guid Id {get; set;}
        [Required]
        public string Message { get; set; }

        [Required]
        public Guid ContactId { get; set; }

        public long UnixTimestamp {get; set;}


    }
}
