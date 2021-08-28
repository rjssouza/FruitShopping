using Core.Domain.Services;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Security.Domain.Entities;
using Security.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Security.Domain.Services
{
    internal class ApplicationUserService : Service, IApplicationUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
        }

        public async Task<bool> Insert(ApplicationUser applicationUser, string password)
        {
            applicationUser.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(applicationUser, password);

            return result.Succeeded;
        }

        public async Task<bool> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

            return result.Succeeded;
        }

        public async Task<LogoutRequest> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interaction.GetLogoutContextAsync(logoutId);

            return logoutRequest;
        }
    }
}