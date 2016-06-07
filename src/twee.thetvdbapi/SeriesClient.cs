using System.Threading.Tasks;
using Newtonsoft.Json;

namespace twee.thetvdbapi
{
    public class SeriesClient
    {

        public async Task<SerieResponse> GetById(int id, string token)
        {
            var client = new TheTvDbHttpClient(token);
            var response = await client.HttpClient.GetAsync($"/series/{id}");

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SerieResponse>(result);
        }
    }
}