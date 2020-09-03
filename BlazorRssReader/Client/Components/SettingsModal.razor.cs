using Blazorise;
using BlazorRssReader.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRssReader.Client.Components
{
    public partial class SettingsModal
    {
        [Inject] private IConfiguration _Configuration { get; set; }
        private Modal? _ModalRef;
        private String _SyncPeriodHours { get; set; }
        private String _SyncPeriodMinutes { get; set; }
        private String _SyncPeriodSeconds { get; set; }
        private bool _FormatDescription { get; set; }
        protected override void OnInitialized()
        {
            InitFromConfiguration();
        }
        private void InitFromConfiguration()
        {
            _SyncPeriodHours = (_Configuration.SyncPeriod / 60 / 60).ToString();
            _SyncPeriodMinutes = (_Configuration.SyncPeriod / 60).ToString();
            _SyncPeriodSeconds = (_Configuration.SyncPeriod % 60).ToString();
            _FormatDescription = _Configuration.FormatDescription;
        }
        private void SaveToConfiguration()
        {
            try
            {
                _Configuration.SyncPeriod = Int32.Parse(_SyncPeriodHours) * 60 * 60 + Int32.Parse(_SyncPeriodMinutes) * 60 + Int32.Parse(_SyncPeriodSeconds);
            }
            catch { }
            _Configuration.FormatDescription = _FormatDescription;
        }
        private void ShowModal()
        {
            _ModalRef.Show();
        }

        private void HideModal()
        {
            _ModalRef.Hide();
        }
        private void OnSubmit()
        {
            SaveToConfiguration();
            InitFromConfiguration(); // Todo. Сделано чтобы стереть невалидные данные. Убрать после добавления валидации
            HideModal();
        }
        public void Show()
        {
            ShowModal();
        }
    }
}
