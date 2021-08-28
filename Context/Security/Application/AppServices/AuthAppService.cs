using AutoMapper;
using Core.Application.AppServices;
using Core.Domain.Interfaces.Repositories;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Security.Application.Interfaces.AppServices;
using Security.Application.ViewModels.Account;
using Security.Domain.Entities;
using Security.Domain.Interfaces.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Security.Application
{
    internal class AuthAppService : AppServiceTransaction, IAuthAppService
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IClientStore _clientStore;
        private readonly IEventService _events;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public AuthAppService(IUnitOfWorkTransaction coreUnitOfWorkTransaction,
            IMapper mapper,
            IApplicationUserService applicationUserService,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events)
            : base(coreUnitOfWorkTransaction, mapper)
        {
            _applicationUserService = applicationUserService;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
        }

        public async Task<LoginViewModel> GetLoginViewModel(string returnUrl)
        {
            var vm = await BuildLoginViewModelAsync(returnUrl);

            return vm;
        }

        public async Task<LogoutViewModel> GetLogoutViewModel(string logoutId, ClaimsPrincipal user)
        {
            var vm = await BuildLogoutViewModelAsync(logoutId, user);

            return vm;
        }

        public RegisterViewModel GetRegisterViewModel(string returnUrl)
        {
            var register = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };

            return register;
        }

        public async Task<LoginViewModel> Login(LoginInputModel loginViewModel)
        {
            await _applicationUserService.Login(loginViewModel.Username, loginViewModel.Password);
            var result = await BuildLoginViewModelAsync(loginViewModel);

            return result;
        }

        public async Task<LoggedOutViewModel> Logout(LogoutInputModel model)
        {
            await _applicationUserService.Logout(model.LogoutId);
            var vm = await BuildLoggedOutViewModelAsync(model.LogoutId);

            return vm;
        }

        public async Task<bool> Register(RegisterViewModel applicationUserViewModel)
        {
            var applicationUser = this._mapper.Map<ApplicationUser>(applicationUserViewModel);
            var result = await _applicationUserService.Insert(applicationUser, applicationUserViewModel.Password);

            return result;
        }

        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(logoutId);

            var vm = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            return vm;
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
            {
                var local = context.IdP == IdentityServer4.IdentityServerConstants.LocalIdentityProvider;

                // this is meant to short circuit the UI and only trigger the one external IdP
                var vm = new LoginViewModel
                {
                    EnableLocalLogin = local,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                };

                if (!local)
                {
                    vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
                }

                return vm;
            }

            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName ?? x.Name,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.Client.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.Client.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new LoginViewModel
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }

        private async Task<LogoutViewModel> BuildLogoutViewModelAsync(string logoutId, ClaimsPrincipal user)
        {
            var vm = new LogoutViewModel { LogoutId = logoutId, ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt };

            if (user?.Identity.IsAuthenticated != true)
            {
                // if the user is not authenticated, then just show logged out page
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            var context = await _interaction.GetLogoutContextAsync(logoutId);
            if (context?.ShowSignoutPrompt == false)
            {
                // it's safe to automatically sign-out
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            // show the logout prompt. this prevents attacks where the user
            // is automatically signed out by another malicious web page.
            return vm;
        }
    }
}