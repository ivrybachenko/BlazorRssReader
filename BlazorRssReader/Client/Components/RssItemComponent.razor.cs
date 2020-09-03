using BlazorRssReader.Client.Services;
using BlazorRssReader.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRssReader.Client.Components
{
    public partial class RssItemComponent
    {
        [Inject] private IConfiguration _Configuration { get; set; }
        [Parameter] public RssItem? Item { get; set; }
        private bool _Collapsed { get; set; } = true;
        protected override void OnInitialized()
        {
            _Configuration.FormatDescriptionChanged += OnFormatDescriptionChanged;
        }
        private void OnFormatDescriptionChanged(bool format)
        {
            StateHasChanged();
        }
        private String ToggleDescriptionText
        {
            get
            {
                return _Collapsed ? "Развернуть" : "Свернуть";
            }
        }
        private void ToggleDescription()
        {
            _Collapsed = !_Collapsed;
        }
    }
}
