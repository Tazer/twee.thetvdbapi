using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace twee.thetvdbapi
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".

    public static class TheTvDbHttpClient
    {
        private static readonly HttpClient _httpClient = new HttpClient() {BaseAddress = new Uri("https://api.thetvdb.com"),DefaultRequestHeaders = { Accept = { new MediaTypeWithQualityHeaderValue("application/json") } }};

        public static HttpClient GetClient()
        {
            return _httpClient;
        }
        
    }
}
