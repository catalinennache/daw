using Chatty.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Chatty.Utils.JWTutils;

namespace Chatty.Utils
{
    public class JWTMiddleware
    {

        private readonly RequestDelegate _next;

        public async Task Invoke(HttpContext httpContext, IUnitOfWork unitOfWork, IJWTUtils jWTUtils)
        {

            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            var userId = jWTUtils.ValidateJWTToken(token);
            if(userId!=Guid.Empty)
            {
                httpContext.Items["User"] = unitOfWork.GetUserRepository().FindById(userId);
            }
            await _next(httpContext);
        }
    }
}
