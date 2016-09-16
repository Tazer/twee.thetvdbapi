using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace twee.thetvdbapi
{
    public class HttpClientHelper
    {
        public static HttpRequestMessage GetHttpRequestMessage(string url, string token = null)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            if (token != null)
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);



            return requestMessage;
        }

        public static HttpRequestMessage HttpRequestMessage<T>(HttpMethod method, string url, string token = null, object content = null)
        {
            var requestMessage = new HttpRequestMessage(method, url);
            if (token != null)
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            if (content != null)
                requestMessage.Content = new ObjectContent(typeof(T), content, new JsonMediaTypeFormatter(), "application/json");


            return requestMessage;
        }
    }
}
