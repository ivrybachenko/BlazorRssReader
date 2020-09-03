using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRssReader.Server.Services;
using BlazorRssReader.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorRssReader.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RssController : ControllerBase
    {
        private readonly IRssLoader _RssLoader;

        public RssController(IRssLoader rssLoader)
        {
            _RssLoader = rssLoader;
        }
        [Route("{url}")]
        [HttpGet]
        public async Task<IEnumerable<RssItem>> Get(String url)
        {
            return await _RssLoader.Download(System.Net.WebUtility.UrlDecode(url));
        }
    }
}
