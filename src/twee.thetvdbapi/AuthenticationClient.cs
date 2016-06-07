using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace twee.thetvdbapi
{
    public class AuthenticationClient
    {
        public async Task<TokenResponse> Login(string apikey, string username, string userkey)
        {
            var client = new TheTvDbHttpClient();

            var request = new { apikey, username, userkey };

            var response = await client.HttpClient.PostAsJsonAsync("/login", request);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TokenResponse>(result);
        }

        public async Task<TokenResponse> RefreshToken(string token)
        {
            var client = new TheTvDbHttpClient();

            var request = new { token };

            var response = await client.HttpClient.PostAsJsonAsync("/refresh_token", request);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TokenResponse>(result);
        }
    }
}