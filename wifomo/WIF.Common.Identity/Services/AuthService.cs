using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using WIF.PortfolioManager.Application.Exceptions;
using WIF.PortfolioManager.Application;
using WIF.Common.Identity.Models;
using WIF.PortfolioManager.Application.Contracts;
using WIF.PortfolioManager.Application.Models.Authentication;
using WIF.PortfolioManager.Application.Models.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WIF.PortfolioManager.Application.Contracts.Identity;
using System.ComponentModel;
using System.Diagnostics;
using Npgsql.Internal.TypeHandlers;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace WIF.Common.Identity.Services
{

    
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
               signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundException($"User with {request.Email} not found.", request.Email);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded == false)
            {
                throw new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "USER");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }

                throw new BadRequestException($"{str}");
            }
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        
        public async Task ConfirmEmail(ConfirmEmailRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                // missing user, proceed.
            }
            var result = await _userManager.ConfirmEmailAsync(user, request.Code);

            if(result.Succeeded == false)
            {
                //StringBuilder str = new StringBuilder();
                //foreach (var err in result.Errors)
                //{
                //    str.AppendFormat("•{0}\n", err.Description);
                //}
                //throw new BadRequestException($"{str}");

                // failed to confirm, proceed
            }
        }

        public async Task ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // missing user, proceed.
            }
            else
            {
                var result = await _userManager.IsEmailConfirmedAsync(user);

                if (result == false)
                {
                    //StringBuilder str = new StringBuilder();
                    //foreach (var err in result.Errors)
                    //{
                    //    str.AppendFormat("•{0}\n", err.Description);
                    //}
                    //throw new BadRequestException($"{str}");

                    // failed to confirm, proceed
                    return;
                }

                //@TODO - implement email service
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                //var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                //   "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");

            }

        }
        public async Task ResetPassword(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                // missing user, proceed.
            }
            else
            {
                var result = await _userManager.ResetPasswordAsync(user, request.Code, request.Password);
                if (result.Succeeded == false)
                {
                    //StringBuilder str = new StringBuilder();
                    //foreach (var err in result.Errors)
                    //{
                    //    str.AppendFormat("{0}\n", err.Description);
                    //}
                    //throw new BadRequestException($"{str}");

                    // failed to reset, proceed
                }
            }
            
        }
    }
}
