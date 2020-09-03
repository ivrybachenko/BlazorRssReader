using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRssReader.Client.Components
{
    public partial class HeaderComponent
    {
        [Parameter] public String Title { get; set; }
        [Parameter] public bool IsLoadingInProgress { get; set; } = false;
        [Parameter] public Action SidebarToggleClicked { get; set; }
        [Parameter] public Action SettingsClicked { get; set; }
        [Parameter] public Action SyncClicked { get; set; }
        private String SyncIconClass() => IsLoadingInProgress ? "fa-spin" : "";
    }
}
