namespace WarframeDashboard.Tools
{
    public static class ConvertTimezone
    {
        public static DateTime Convert(DateTime date, string? newTimezone)
        {
            if (newTimezone == null) return date;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(newTimezone);
            return TimeZoneInfo.ConvertTimeFromUtc(date, timeZoneInfo);
        }
    }
}