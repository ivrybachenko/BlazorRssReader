using System.Xml;
using System.Linq;
using BlazorRssReader.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace BlazorRssReader.Client.Services
{
    class RssService : IRssService
    {
        private HttpClient _HttpClient;
        public RssService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }
        public async Task<IEnumerable<RssItem>?> Download(string url)
        {
            string requestUrl = $"Rss/{System.Net.WebUtility.UrlEncode(url)}";
            try
            {
                return await _HttpClient.GetFromJsonAsync<IEnumerable<RssItem>>(requestUrl);
            }
            catch
            {
                return null;
            }
        }
    }
}