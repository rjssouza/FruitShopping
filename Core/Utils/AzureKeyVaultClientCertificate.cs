using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Core.Utils
{
    public class AzureKeyVaultClientCertificate
    {
        private readonly CertificateClient _client;

        public AzureKeyVaultClientCertificate(IConfiguration configuration)
        {
            var kvUrl = new Uri(configuration["KeyVaultConfig:KvUrl"]);
            var tentantId = configuration["KeyVaultConfig:TenantId"];
            var clientId = configuration["KeyVaultConfig:ClientId"];
            var clientSecret = configuration["KeyVaultConfig:ClientSecretId"];
            var credential = new ClientSecretCredential(tentantId, clientId, clientSecret);

            this._client = new CertificateClient(vaultUri: kvUrl, credential: credential);
        }

        public KeyVaultCertificate GetCertificate(string certificateName)
        {
            KeyVaultCertificateWithPolicy certificateWithPolicy = this._client.GetCertificate(certificateName);
            KeyVaultCertificate certificate = this._client.GetCertificateVersion(certificateWithPolicy.Name, certificateWithPolicy.Properties.Version);

            return certificate;
        }

        public List<CertificateProperties> ListCertificates()
        {
            Pageable<CertificateProperties> allCertificates = this._client.GetPropertiesOfCertificates();
            var result = new List<CertificateProperties>();
            foreach (var properties in allCertificates)
                result.Add(properties);

            return result;
        }
    }
}