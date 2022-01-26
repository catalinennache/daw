
using System;
using System.Threading.Tasks;
using Chatty.Models;
using Chatty.Data;
using Chatty.Models.DTOs;

namespace Chatty.Core
{
    public interface IAuthService
    {
        public UserResponseDTO Authenticate(User user);
        public string Register(User user);


    }
}