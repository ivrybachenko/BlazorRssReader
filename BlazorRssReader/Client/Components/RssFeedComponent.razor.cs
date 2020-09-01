using BlazorRssReader.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRssReader.Client.Components
{
    public partial class RssFeedComponent
    {
        [Parameter]
        public IEnumerable<RssItem> Items { get; set; }
    }
}
