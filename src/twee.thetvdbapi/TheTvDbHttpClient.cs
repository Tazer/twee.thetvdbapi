using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace twee.thetvdbapi
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".


    public class TheTvDbHttpClient
    {
        public TheTvDbHttpClient()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://api.thetvdb.com");
        }

        public TheTvDbHttpClient(string token)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://api.thetvdb.com");
            HttpClient.SetBearerToken(token);
        }

        public HttpClient HttpClient { get; set; }
    }
}
