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
            var client = TheTvDbHttpClient.GetClient();

            var request = new { apikey, username, userkey };

            var response = await client.PostAsJsonAsync("/login", request);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"[{response.StatusCode}] {result}");
                return new TokenResponse() { Error = $"Error {response.StatusCode}" };
            }

            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);

            var securityTokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            var jwtToken = securityTokenHandler.ReadJwtToken(tokenResponse.Token);

            tokenResponse.Expire = jwtToken.Payload.Exp;

            return tokenResponse;
        }

        public async Task<TokenResponse> RefreshToken(string token)
        {
            var client = TheTvDbHttpClient.GetClient();

            var request = new { token };

            var response = await client.PostAsJsonAsync("/refresh_token", request);

            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"[{response.StatusCode}] {result}");
                return new TokenResponse() {Error = $"Error {response.StatusCode}"};
            }

            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);

            var securityTokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            var jwtToken = securityTokenHandler.ReadJwtToken(tokenResponse.Token);

            tokenResponse.Expire = jwtToken.Payload.Exp;

            return tokenResponse;
        }
    }
}