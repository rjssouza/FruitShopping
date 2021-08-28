using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.AntiCorruption.Extensions
{
    public static class ApiAntiCorruptionExtensions
    {
        public static async Task<TRetorno> GetFromResponseAsync<TRetorno>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return default;

            var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<TRetorno>(stream);

            return result;
        }

        public static async Task<string> GetStringFromResponseAsync(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}