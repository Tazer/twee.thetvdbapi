using System.Threading.Tasks;
using Newtonsoft.Json;
using twee.thetvdbapi.Models;

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
        //TODO: add support for paging
        public async Task<EpisodesResponse> GetEpisodesBySerieId(int id, string token)
        {
            var client = new TheTvDbHttpClient(token);
            var response = await client.HttpClient.GetAsync($"/series/{id}/episodes");

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EpisodesResponse>(result);
        }

        public async Task<ActorsResponse> GetActorsBySerieId(int id, string token)
        {
            var client = new TheTvDbHttpClient(token);
            var response = await client.HttpClient.GetAsync($"/series/{id}/actors");

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ActorsResponse>(result);
        }

        public async Task<ImageSummaryResponse> GetImageSummaryBySerieId(int id, string token)
        {
            var client = new TheTvDbHttpClient(token);
            var response = await client.HttpClient.GetAsync($"/series/{id}/images");

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ImageSummaryResponse>(result);
        }
    }
}