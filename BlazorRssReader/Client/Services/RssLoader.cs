using System.Xml;
using System.Linq;
using BlazorRssReader.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace BlazorRssReader.Client.Services
{
    class RssLoader : IRssLoader
    {
        private HttpClient httpClient;
        public RssLoader(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<RssItem>> Download(string url)
        {
            string requestUrl = $"Rss/{System.Net.WebUtility.UrlEncode(url)}";
            return await httpClient.GetFromJsonAsync<IEnumerable<RssItem>>(requestUrl);
        }
    }
}