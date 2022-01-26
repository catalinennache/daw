using System;
using Chatty.Models;

namespace Chatty.Models.DTOs
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public UserResponseDTO(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Token = token;
        }
    }
}
