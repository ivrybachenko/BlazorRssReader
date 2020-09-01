using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorRssReader.Client.Models
{
    public class RssFeed
    {
        public String Title { get; set; }
        public String Url { get; set; }

        public RssFeed(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}
