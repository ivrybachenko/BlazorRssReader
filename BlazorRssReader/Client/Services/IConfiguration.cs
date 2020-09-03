namespace BlazorRssReader.Client.Services
{
    public interface IConfiguration
    {
        bool FormatDescription { get; set; }
        int SyncPeriod { get; set; }

        event Configuration.SyncPeriodChangedHandler SyncPeriodChanged;
        event Configuration.FormatDescriptionChangedHandler FormatDescriptionChanged;
    }
}