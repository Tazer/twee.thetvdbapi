using System.Threading.Tasks;
using Newtonsoft.Json;
using twee.thetvdbapi.Models;

namespace twee.thetvdbapi
{
    public class SeriesClient
    {

        public async Task<SerieResponse> GetById(int id, string token)
        {
            var client = TheTvDbHttpClient.GetClient();
            var response = await client.SendAsync(HttpClientHelper.GetHttpRequestMessage($"/series/{id}", token));

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SerieResponse>(result);
        }
        //TODO: add support for paging
        public async Task<EpisodesResponse> GetEpisodesBySerieId(int id, string token, int page = 1)
        {
            var client = TheTvDbHttpClient.GetClient();

            var parametersToAdd = new System.Collections.Generic.Dictionary<string, string>();

            if (page != 1)
                parametersToAdd.Add("page", page.ToString());

            var queryUrl = $"/series/{id}/episodes";
            var queryUrlWithParameters = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(queryUrl, parametersToAdd);

            var response = await client.SendAsync(HttpClientHelper.GetHttpRequestMessage(queryUrlWithParameters, token));

            var result = await response.Content.ReadAsStringAsync();
            var parsedResult = JsonConvert.DeserializeObject<EpisodesResponse>(result);

            parsedResult.Links.Current = page;

            return parsedResult;
        }

        public async Task<ActorsResponse> GetActorsBySerieId(int id, string token)
        {
            var client = TheTvDbHttpClient.GetClient();
            var response = await client.SendAsync(HttpClientHelper.GetHttpRequestMessage($"/series/{id}/actors", token));

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ActorsResponse>(result);
        }

        public async Task<ImageSummaryResponse> GetImageSummaryBySerieId(int id, string token)
        {
            var client = TheTvDbHttpClient.GetClient();
            var response = await client.SendAsync(HttpClientHelper.GetHttpRequestMessage($"/series/{id}/images", token));

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ImageSummaryResponse>(result);
        }

        public async Task<ImageQueryParamsViewModel> GetImageQueryParams(int id, string token)
        {
            var client = TheTvDbHttpClient.GetClient();
            var response = await client.SendAsync(HttpClientHelper.GetHttpRequestMessage($"/series/{id}/images/query/params", token));

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ImageQueryParamsViewModel>(result);
        }

        public async Task<ImageQueryViewModel> GetImageQuery(int id, string keyType, string token, string resolution = "", string subKey = "")
        {
            var client = TheTvDbHttpClient.GetClient();

            var parametersToAdd = new System.Collections.Generic.Dictionary<string, string>();

            if (!string.IsNullOrEmpty(keyType))
                parametersToAdd.Add("keyType", keyType);
            if (!string.IsNullOrEmpty(resolution))
                parametersToAdd.Add("resolution", resolution);
            if (!string.IsNullOrEmpty(subKey))
                parametersToAdd.Add("subKey", subKey);

            var queryUrl = $"/series/{id}/images/query";
            var queryUrlWithParameters = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(queryUrl, parametersToAdd);

            var response = await client.SendAsync(HttpClientHelper.GetHttpRequestMessage(queryUrlWithParameters, token));

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ImageQueryViewModel>(result);
        }
    }
}