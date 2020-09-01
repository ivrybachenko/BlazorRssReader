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
        [Parameter]
        public RssItem? Item { get; set; }
        private bool Collapsed { get; set; } = true;
        private String ToggleDescriptionText
        {
            get
            {
                return Collapsed ? "Развернуть" : "Свернуть";
            }
        }
        private void ToggleDescription()
        {
            this.Collapsed = !Collapsed;
        }
    }
}
