using Core.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Core.Data.Context
{
    public abstract class CoreDbContext : DbContext
    {
        private const string DB_NAME = "estudodb";
        private static bool updateDatabase = true;
        private readonly IConfiguration _configuration;

        public CoreDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);

            if (updateDatabase)
            {
                Database.Migrate();
                updateDatabase = false;
            }
        }

        protected abstract string DbName { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = this._configuration[ConfigKeyConstants.STRING_CONNECTION];
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(string.Format(connectionString, this.DbName ?? DB_NAME), x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
            }

            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(assembly: this.GetType().Assembly);
        }
    }
}