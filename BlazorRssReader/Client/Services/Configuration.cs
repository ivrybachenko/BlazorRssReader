using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRssReader.Client.Services
{
    public class Configuration : IConfiguration
    {
        private Int32 _SyncPeriod = 60;
        public Int32 SyncPeriod
        {
            get
            {
                return _SyncPeriod;
            }
            set
            {
                if (_SyncPeriod == value)
                {
                    return;
                }
                _SyncPeriod = value;
                SyncPeriodChanged?.Invoke(_SyncPeriod);
            }
        }
        private bool _FormatDescription = false;
        public bool FormatDescription
        {
            get
            {
                return _FormatDescription;
            }
            set
            {
                if (_FormatDescription == value)
                {
                    return;
                }
                _FormatDescription = value;
                FormatDescriptionChanged?.Invoke(_FormatDescription);
            }
        }
        public delegate void SyncPeriodChangedHandler(Int32 syncPeriod);
        public event SyncPeriodChangedHandler SyncPeriodChanged;
        public delegate void FormatDescriptionChangedHandler(bool formatDescription);
        public event FormatDescriptionChangedHandler FormatDescriptionChanged;
    }
}
