using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.Contracts.Identity;
using WIF.PortfolioManager.Application.Contracts.Persistence;

namespace WIF.PortfolioManager.Application.Services
{
    public class UserService: ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IApplicationUser<string>> GetUser(IApplicationUser<string> user)
        {
            return await _unitOfWork.UserRepository.GetUser(user);
        }
        public async Task<IApplicationUser<string>> GetUserByEmail(string email)
        {
            return await _unitOfWork.UserRepository.GetUserByEmail(email);
        }
    }
}
