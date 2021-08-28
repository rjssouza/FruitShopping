using Security.Application.ViewModels.Account;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Security.Application.Interfaces.AppServices
{
    public interface IAuthAppService : IDisposable
    {
        Task<LoginViewModel> GetLoginViewModel(string returnUrl);

        Task<LogoutViewModel> GetLogoutViewModel(string logoutId, ClaimsPrincipal user);

        RegisterViewModel GetRegisterViewModel(string returnUrl);

        Task<LoginViewModel> Login(LoginInputModel loginViewModel);

        Task<LoggedOutViewModel> Logout(LogoutInputModel model);

        Task<bool> Register(RegisterViewModel applicationUserViewModel);
    }
}