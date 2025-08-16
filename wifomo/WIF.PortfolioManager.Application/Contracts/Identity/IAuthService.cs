using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.Models.Authentication;
using WIF.PortfolioManager.Application.Models.Identity;

namespace WIF.PortfolioManager.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task Logout();
        Task ConfirmEmail(ConfirmEmailRequest request);
        Task ForgotPassword(string email);
        Task ResetPassword(ResetPasswordRequest request);
    }
}
