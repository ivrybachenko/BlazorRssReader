using BlazorRssReader.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRssReader.Server.Services
{
    public interface IRssLoader
    {
        Task<IEnumerable<RssItem>?> Download(string url);
    }
}
