using System.Runtime.CompilerServices;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WIF.PortfolioManager.Application.Contracts.Identity;
using WIF.PortfolioManager.Application.Models.Authentication;
using WIF.PortfolioManager.Application.Models.Identity;

namespace WIF.PortfolioManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        //[Consumes("application/json")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("register")]
        [AllowAnonymous]
        //[Consumes("application/json")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }
        [HttpGet("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _authenticationService.Logout();
            return Ok();
        }
        [HttpPost("confirm-email")]
        [Authorize]
        public async Task<ActionResult> ConfirmEmail(ConfirmEmailRequest request)
        {
                await _authenticationService.ConfirmEmail(request);
            return Ok();
        }
        [HttpGet("forgot-password")]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            await _authenticationService.ForgotPassword(email);
            return Ok();
        }
        [HttpPost("reset-password")]
        [Authorize]
        public async Task<ActionResult> ResetPassword(ResetPasswordRequest request)
        {
            await _authenticationService.ResetPassword(request);
            return Ok();
        }
        [HttpGet("test")]
        [Authorize]
        public async Task<ActionResult> Test()
        {
            return Ok();
        }
    }
}
