using Microsoft.AspNetCore.Identity;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Security.Domain.Entities
{
    internal class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public DateTime? CreationDate { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public bool? OldHash { get; set; }
    }
}