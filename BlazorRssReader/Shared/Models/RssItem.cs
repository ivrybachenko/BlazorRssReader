using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorRssReader.Shared.Models
{
    public class RssItem
    {
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public String Url { get; set; }
        public RssItem() { }
        public RssItem(string title, DateTime date, string description, string url)
        {
            this.Title = title;
            this.Date = date;
            this.Description = description;
            this.Url = url;
        }
    }
}
