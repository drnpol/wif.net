using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using WIF.PortfolioManager.Application.Contracts.Identity;

namespace WIF.PortfolioManager.API.Middlewares
{
    public class AuthenticationMiddleware : IMiddleware
    {
        private readonly IAuthService _authService;
        public AuthenticationMiddleware(IAuthService authService)
        {
            this._authService = authService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string? token = context.Request.Headers[HeaderNames.Authorization];

            if (!token.IsNullOrEmpty())
            {
                if (await this.ValidateToken(token))
                {
                    await next(context);
                }
            }
        }
        //@TODO
        private async Task<bool> ValidateToken(string token)
        {
            return true;
        }
    }
}
