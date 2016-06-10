using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using twee.thetvdbapi.Models;

namespace twee.thetvdbapi
{
    public class SearchClient
    {
        public async Task<SearchParamsResponse> GetSearchParams(string token)
        {
            var client = new TheTvDbHttpClient(token);
            var response = await client.HttpClient.GetAsync($"/search/series/params");

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SearchParamsResponse>(result);
        }

        public async Task<SearchResponse> GetSearch(string token, string name = "", string imdbId = "", string zap2ItId = "")
        {
            var client = new TheTvDbHttpClient(token);

            var parametersToAdd = new System.Collections.Generic.Dictionary<string, string>();

            if (!string.IsNullOrEmpty(name))
                parametersToAdd.Add("name", name);
            if (!string.IsNullOrEmpty(imdbId))
                parametersToAdd.Add("imdbId", imdbId);
            if (!string.IsNullOrEmpty(zap2ItId))
                parametersToAdd.Add("zap2ItId", zap2ItId);

            var queryUrl = $"/search/series";
            var queryUrlWithParameters = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(queryUrl, parametersToAdd);

            var response = await client.HttpClient.GetAsync(queryUrlWithParameters);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SearchResponse>(result);
        }


    }

    public class SearchParamsResponse
    {
        public SearchParams Data { get; set; }
    }

    public class SearchParams
    {
        public string[] Params { get; set; }
    }

    public class SearchResponse
    {
        public IEnumerable<Search> Data { get; set; }
    }

    public class Search
    {


        public string[] Aliases { get; set; }
        public string Banner { get; set; }
        public string FirstAired { get; set; }
        public int Id { get; set; }
        public string Network { get; set; }
        public string Overview { get; set; }
        public string SeriesName { get; set; }
        public string Status { get; set; }
    }

}