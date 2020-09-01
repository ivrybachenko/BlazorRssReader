using Blazorise;
using Blazorise.Sidebar;
using BlazorRssReader.Client.Services;
using BlazorRssReader.Client.Models;
using BlazorRssReader.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRssReader.Client.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorRssReader.Client.Pages
{
    public partial class Index
    {
        private Sidebar sidebar;
        private SettingsModal settingsModalRef;
        private RssFeed feed = new RssFeed("Хабр. Интересное", "https://habr.com/ru/rss/interesting/");
        private IEnumerable<RssItem>? items = null;
        [Inject]
        private IRssLoader rssLoader { get; set; }
        private SidebarInfo sidebarInfo = new SidebarInfo
        {
            Brand = new SidebarBrandInfo
            {
                Text = "RSS ленты"
            },
            Items = new List<SidebarItemInfo>
            {
                new SidebarItemInfo { To = "", Text = "Хабр. Интересное" },
                new SidebarItemInfo { To = "", Text = "РИА Новости" },
            }
        };
        void ToggleSidebar()
        {
            sidebar.Toggle();
        }

        private void ShowSettingsModal()
        {
            settingsModalRef.Show();
        }
        public async void SyncFeed()
        {
            this.items = await rssLoader.Download(feed.Url);
        }
    }
}
