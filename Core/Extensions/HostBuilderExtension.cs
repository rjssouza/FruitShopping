using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Core.Extensions
{
    public static class HostBuilderExtension
    {
        /// <summary>
        /// Opção para registro de app sem certificado
        /// </summary>
        /// <param name="webBuilder"></param>
        public static void ConfigureAzureKeyVault(this IWebHostBuilder webBuilder)
        {
            webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var builtConfig = config.Build();
                var kvUrl = new Uri(builtConfig["KeyVaultConfig:KvUrl"]);
                var tentantId = builtConfig["KeyVaultConfig:TenantId"];
                var clientId = builtConfig["KeyVaultConfig:ClientId"];
                var clientSecret = builtConfig["KeyVaultConfig:ClientSecretId"];
                var credential = new ClientSecretCredential(tentantId, clientId, clientSecret);
                var secretClient = new SecretClient(kvUrl, credential);

                config.AddAzureKeyVault(secretClient, new AzureKeyVaultConfigurationOptions());
            });
        }

        /// <summary>
        /// Opção para registro de app com certificado
        /// </summary>
        /// <param name="webBuilder"></param>
        public static void ConfigureAzureKeyVaultWithCertificate(this IWebHostBuilder webBuilder)
        {
            webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var builtConfig = config.Build();
                var kvUrl = new Uri(builtConfig["KeyVaultConfig:KvUrl"]);
                var tentantId = builtConfig["KeyVaultConfig:TenantId"];
                var clientId = builtConfig["KeyVaultConfig:ClientId"];

                using var store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                var certs = store.Certificates
                    .Find(X509FindType.FindByThumbprint,
                        "Thumbprint", false);

                    config.AddAzureKeyVault(kvUrl,
                        new ClientCertificateCredential(tentantId, clientId, certs.OfType<X509Certificate2>().Single()));

                    store.Close();
            });
        }
    }
}