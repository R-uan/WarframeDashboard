namespace WarframeDashboard.Services
{
    public class TimezoneService
    {
        public string? Timezone { get; set; }

        public void SetTimezone(string timezone)
        {
            this.Timezone = timezone;
        }
    }
}