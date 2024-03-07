namespace algorithm.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime MarkAsUtc(this DateTime dateTime) => DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        public static DateTime? MarkAsUtc(this DateTime? time)
        {
            return time.HasValue ? DateTime.SpecifyKind(time.Value, DateTimeKind.Utc) : (DateTime?)null;
        }
    }
}
