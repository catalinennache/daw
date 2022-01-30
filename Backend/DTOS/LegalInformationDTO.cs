using System.ComponentModel.DataAnnotations;
using System;
namespace Chatty.Models.DTOs
{
    public class LegalInformationDTO
    {
        public Guid Id {get; set;}

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonalIdentificationNumber { get; set; }

        public string CardNumber{get;set;}
        public string Address{get;set;}
        [Required]
        public Guid User { get; set; }


    }
}
