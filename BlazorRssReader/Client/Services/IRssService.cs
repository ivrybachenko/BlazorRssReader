using BlazorRssReader.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRssReader.Client.Services
{
    public interface IRssService
    {
        Task<IEnumerable<RssItem>?> Download(string url);
    }
}
