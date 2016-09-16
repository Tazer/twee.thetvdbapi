using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace twee.thetvdbapi
{
    public class AuthenticationClient
    {
        private readonly ILogger _logger;

        public AuthenticationClient(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TokenResponse> Login(string apikey, string username = "", string userkey = "")
        {
            var client = new TheTvDbHttpClient();

            var request = new { apikey, username, userkey };

            var response = await client.HttpClient.PostAsJsonAsync("/login", request);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"[{response.StatusCode}] {result}");
                return new TokenResponse() { Error = $"Error {response.StatusCode}" };
            }

            return JsonConvert.DeserializeObject<TokenResponse>(result);
        }

        public async Task<TokenResponse> RefreshToken(string token)
        {
            var client = new TheTvDbHttpClient();

            var request = new { token };

            var response = await client.HttpClient.PostAsJsonAsync("/refresh_token", request);

            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"[{response.StatusCode}] {result}");
                return new TokenResponse() {Error = $"Error {response.StatusCode}"};
            }

            return JsonConvert.DeserializeObject<TokenResponse>(result);
        }
    }
}