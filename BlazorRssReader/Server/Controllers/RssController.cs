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

        private readonly ILogger<RssController> logger;
        private readonly IRssLoader rssLoader;

        public RssController(ILogger<RssController> logger, IRssLoader rssLoader)
        {
            this.logger = logger;
            this.rssLoader = rssLoader;
        }
        [Route("{url}")]
        [HttpGet]
        public async Task<IEnumerable<RssItem>> Get(String url)
        {
            return await rssLoader.Download(System.Net.WebUtility.UrlDecode(url));
        }
    }
}
