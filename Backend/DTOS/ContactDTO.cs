using System.ComponentModel.DataAnnotations;
using System;
namespace Chatty.Models.DTOs
{
    public class ContactDTO
    {
        public Guid Id {get; set;}
        [Required]
        public string NickName { get; set; }

        [Required]
        public Guid Owner { get; set; }

        [Required]
        public Guid User { get; set; }


    }
}
