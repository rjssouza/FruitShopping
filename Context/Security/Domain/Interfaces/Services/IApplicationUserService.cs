using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication;
using Security.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Security.Domain.Interfaces.Services
{
    internal interface IApplicationUserService
    {
        Task<bool> Insert(ApplicationUser applicationUser, string password);

        Task<bool> Login(string userName, string password);

        Task<LogoutRequest> Logout(string logoutId);
    }
}