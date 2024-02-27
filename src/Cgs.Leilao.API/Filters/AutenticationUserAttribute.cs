﻿using Cgs.Leilao.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cgs.Leilao.API.Filters
{
    public class AutenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IUserRepository _userRepository;

        public AutenticationUserAttribute(IUserRepository userRepository) => _userRepository = userRepository;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);

                var email = FromBase64String(token);

                var exists = _userRepository.ExistsUserEmail(email);

                if (!exists)
                {
                    context.Result = new UnauthorizedObjectResult("Token is not valid.");
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest (HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();

            if(string.IsNullOrEmpty(authentication) ) { throw new Exception("Token is missing."); }

            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
