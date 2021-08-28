using Core.AntiCorruption.Extensions;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.AntiCorruption
{
    public abstract class ApiAntiCorruption : IDisposable
    {
        private readonly IHttpClientFactory _clientFactory;
        private bool disposedValue;
        protected abstract string BaseUrl { get; }

        public ApiAntiCorruption(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        protected void Delete<TKey>(string uri, TKey id)
        {
            Task.Run(async () =>
            {
                await this.DeleteAsync<TKey>(uri, id);
            });
        }

        protected async Task DeleteAsync<TKey>(string uri, TKey id)
        {
            var formattedUrl = $"{uri}//{id}";
            var request = new HttpRequestMessage(HttpMethod.Delete, formattedUrl);
            var client = this.GetClient();
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        protected TRetorno Get<TRetorno>(string uri)
            where TRetorno : class
        {
            TRetorno result = null;

            Task.Run(async () =>
            {
                result = await this.GetAsync<TRetorno>(uri);
            }).Wait();

            return result;
        }

        protected string Get(string uri)
        {
            string result = null;

            Task.Run(async () =>
            {
                result = await this.GetAsync(uri);
            }).Wait();

            return result;
        }

        protected async Task<TRetorno> GetAsync<TRetorno>(string uri)
                    where TRetorno : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var client = this._clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var result = await response.GetFromResponseAsync<TRetorno>();

            return result;
        }

        protected async Task<string> GetAsync(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var client = this.GetClient();
            var response = await client.SendAsync(request);
            var result = await response.GetStringFromResponseAsync();

            return result;
        }

        protected TRetorno Post<TRetorno, TObject>(string uri, TObject obj)
            where TRetorno : class
        {
            TRetorno result = null;
            Task.Run(async () =>
            {
                result = await this.PostAsync<TRetorno, TObject>(uri, obj);
            }).Wait();

            return result;
        }

        protected void Post<TObject>(string uri, TObject obj)
        {
            Task.Run(async () =>
            {
                await this.PostAsync<TObject>(uri, obj);
            }).Wait();
        }

        protected async Task<TRetorno> PostAsync<TRetorno, TObject>(string uri, TObject obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json")
            };
            var client = this.GetClient();
            var response = await client.SendAsync(request);
            var result = await response.GetFromResponseAsync<TRetorno>();

            return result;
        }

        protected async Task PostAsync<TObject>(string uri, TObject obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json")
            };
            var client = this.GetClient();
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        protected string PostString<TObject>(string uri, TObject obj)
        {
            string result = string.Empty;
            Task.Run(async () =>
            {
                result = await this.PostStringAsync<TObject>(uri, obj);
            }).Wait();

            return result;
        }

        protected async Task<string> PostStringAsync<TObject>(string uri, TObject obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json")
            };
            var client = this.GetClient();
            var response = await client.SendAsync(request);
            var result = await response.GetStringFromResponseAsync();

            return result;
        }

        protected void Put<TObject>(string uri, TObject obj)
        {
            Task.Run(async () =>
            {
                await this.PutAsync<TObject>(uri, obj);
            }).Wait();
        }

        protected async Task PutAsync<TObject>(string uri, TObject obj)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json")
            };
            var client = this.GetClient();
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        private HttpClient GetClient()
        {
            var client = this._clientFactory.CreateClient();
            client.BaseAddress = new Uri(this.BaseUrl);

            return client;
        }
    }
}