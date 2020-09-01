using Blazorise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRssReader.Client.Components
{
    public partial class SettingsModal
    {
        private Modal? modalRef;
        private void ShowModal()
        {
            modalRef.Show();
        }

        private void HideModal()
        {
            modalRef.Hide();
        }
        public void Show()
        {
            ShowModal();
        }
    }
}
