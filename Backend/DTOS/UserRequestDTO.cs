using System.ComponentModel.DataAnnotations;

namespace Chatty.Models.DTOs
{
    public class UserRequestDTO
    {
      
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
