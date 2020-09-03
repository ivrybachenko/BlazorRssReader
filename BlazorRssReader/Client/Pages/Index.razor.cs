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
using System.Threading;

namespace BlazorRssReader.Client.Pages
{
    public partial class Index
    {
        [Inject] private IRssService _RssService { get; set; }
        [Inject] private IConfiguration _Configuration { get; set; }
        private Sidebar _Sidebar;
        private SettingsModal _SettingsModalRef;
        private RssFeed _Feed = new RssFeed("Хабр. Интересное", "https://habr.com/ru/rss/interesting/");
        private IEnumerable<RssItem>? _Items = Enumerable.Empty<RssItem>();
        private bool _IsLoadingInProgress = false;
        private Timer? _SyncTimer = null;
        private SidebarInfo _SidebarInfo = new SidebarInfo
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
        protected override void OnInitialized()
        {
            _Configuration.SyncPeriodChanged += StartSyncInterval;
            StartSyncInterval(_Configuration.SyncPeriod);
        }
        private void ToggleSidebar()
        {
            _Sidebar.Toggle();
        }

        private void ShowSettingsModal()
        {
            _SettingsModalRef.Show();
        }
        private async Task SyncFeed()
        {
            _IsLoadingInProgress = true;
            StateHasChanged();
            _Items = await _RssService.Download(_Feed.Url);
            _IsLoadingInProgress = false;
            StateHasChanged();
        }
        private void StartSyncInterval(Int32 syncPeriodInSeconds)
        {
            if (_SyncTimer != null)
            {
                _SyncTimer.Dispose();
                _SyncTimer = null;
            }
            _SyncTimer = new Timer(async s => await SyncFeed(), null, 0, syncPeriodInSeconds * 1000);
        }
    }
}
