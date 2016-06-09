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

        public async Task<ImageQueryParamsViewModel> GetImageQueryParams(int id, string token)
        {
            var client = new TheTvDbHttpClient(token);
            var response = await client.HttpClient.GetAsync($"/series/{id}/images/query/params");

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ImageQueryParamsViewModel>(result);
        }

        public async Task<ImageQueryViewModel> GetImageQuery(int id, string keyType, string token, string resolution = "", string subKey = "")
        {
            var client = new TheTvDbHttpClient(token);

            var parametersToAdd = new System.Collections.Generic.Dictionary<string, string>();

            if (!string.IsNullOrEmpty(keyType))
                parametersToAdd.Add("keyType", keyType);
            if (!string.IsNullOrEmpty(resolution))
                parametersToAdd.Add("resolution", resolution);
            if (!string.IsNullOrEmpty(subKey))
                parametersToAdd.Add("subKey", subKey);

            var queryUrl = $"/series/{id}/images/query";
            var queryUrlWithParameters = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(queryUrl, parametersToAdd);

            var response = await client.HttpClient.GetAsync(queryUrlWithParameters);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ImageQueryViewModel>(result);
        }
    }
}