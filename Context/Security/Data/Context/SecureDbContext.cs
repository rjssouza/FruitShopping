using Core.Constants;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Security.Domain.Entities;

namespace Security.Data.Context
{
    internal class SecureDbContext : IdentityDbContext<ApplicationUser>
    {
        private const string DB_NAME = "frutasdb";
        private static bool updateDatabase = true;

        private readonly IConfiguration _configuration;

        public SecureDbContext(DbContextOptions<SecureDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

            if (updateDatabase)
            {
                Database.Migrate();
                updateDatabase = false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = this._configuration[ConfigKeyConstants.STRING_CONNECTION];
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(string.Format(connectionString, DB_NAME), x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
            }

            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}