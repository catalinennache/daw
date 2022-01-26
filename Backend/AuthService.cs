using Chatty.Models;
using Chatty.Models.DTOs;
using Chatty.Utils.JWTutils;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Chatty.Core
{
    public class AuthService : IAuthService
    {
        IUnitOfWork _unitOfWork;
        IJWTUtils _iJWTUtils;
           
        public AuthService(IUnitOfWork unitOfWork,  IJWTUtils iJWTUtils)
        {
            _unitOfWork = unitOfWork;
            _iJWTUtils = iJWTUtils;
        }

        public UserResponseDTO Authenticate(User _user)
        {

           var user =  _unitOfWork.GetUserRepository().GetByEmail(_user.Email);
            if (user == null || !BCryptNet.Verify(user.Password, user.PasswordHash))
            {
                return null;
            }
            //JWT generation (Json Web Token)
            var jwtToken = _iJWTUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public string Register(User user)
        {

            _unitOfWork.GetUserRepository().Create(user);
            _unitOfWork.Save();

            var jwtToken = _iJWTUtils.GenerateJWTToken(user);
            return jwtToken;
        }

    }
}