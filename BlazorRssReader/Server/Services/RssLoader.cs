using System.Xml;
using System.Linq;
using System.ServiceModel.Syndication;
using BlazorRssReader.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace BlazorRssReader.Server.Services
{
    class RssLoader : IRssLoader
    {
        private HttpClient _HttpClient;
        public RssLoader(IHttpClientFactory clientFactory)
        {
            _HttpClient = clientFactory.CreateClient();
        }
        public async Task<IEnumerable<RssItem>?> Download(string url)
        {
            try
            {
                XmlReader FeedReader = XmlReader.Create(url);

                SyndicationFeed Channel = SyndicationFeed.Load(FeedReader);
                FeedReader.Close();

                var items = Channel.Items
                    .Select(item => new RssItem(item.Title.Text, item.PublishDate.DateTime,
                        item.Summary.Text, item.Id))
                    .OrderByDescending(s => s.Date);
                
                return items;
            }
            catch
            {
                return null;
            }

        }
    }
}