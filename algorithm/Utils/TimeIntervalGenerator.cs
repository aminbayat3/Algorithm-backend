namespace algorithm.Utils
{
    public class TimeIntervalGenerator
    {
        public static List<Interval> GenerateWeeklyTimestamps(DateTime startDay, int intervalDurationInMinutes)
        {
            var intervals = new List<Interval>();
            DateTime currentTime = startDay;
            DateTime endTime = currentTime.AddDays(7);

            while (currentTime < endTime)
            {
                DateTime start = currentTime;
                DateTime end = currentTime.AddMinutes(intervalDurationInMinutes);
                intervals.Add(new Interval(start, end));
                currentTime = end;
            }

            return intervals;
        }
    }
}
