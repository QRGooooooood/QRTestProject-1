using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Activity.TestProject.Helpers
{
    class CustomerHttpClient
    {
        public static CustomerHttpClient Instance = new CustomerHttpClient();

        public string SendPostRequest(string url, object content, string token, string contentType = "application/json")
        {
            var httpClient = CreateHttpClient(token);
            var httpContent = CreateHttpContent(content, contentType);
            var result = httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string SendPutRequest(string url, object content, string token, string contentType = "application/json")
        {
            var httpClient = CreateHttpClient(token);
            var httpContent = CreateHttpContent(content, contentType);
            var result = httpClient.PutAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string SendDeleteRequest(string url, string token)
        {
            var httpClient = CreateHttpClient(token);
            var result = httpClient.DeleteAsync(url).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string SendGetRequest(string url, string token, string contentType = "application/json")
        {
            var httpClient = CreateHttpClient(token);
            var result = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            return result;
        }

        private HttpContent CreateHttpContent(object content, string contentType)
        {
            var request = JsonConvert.SerializeObject(content);
            HttpContent httpContent = new StringContent(request);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return httpContent;
        }

        private static HttpClient CreateHttpClient(string token)
        {
            var httpClient = new HttpClient();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            }
            return httpClient;
        }
    }
}
