using Chatty.Models;
using System;

namespace Chatty.Utils.JWTutils
{
    public interface IJWTUtils
    {
        public string GenerateJWTToken(User user);
        public Guid ValidateJWTToken(string token);


    }
}
