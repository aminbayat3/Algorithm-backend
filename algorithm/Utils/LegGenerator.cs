using algorithm.Models;

namespace algorithm.Utils
{
    public class LegGenerator 
    {
        public static List<Leg> GenerateTwoDayTimestamps(DateTime startTime, DateTime endTime, int intervalDurationInMinutes)
        {
            var legs = new List<Leg>();

            int counter = 1;

            while (startTime < endTime)
            {
                DateTime start = startTime;
                DateTime end = startTime.AddMinutes(intervalDurationInMinutes);
                legs.Add(new Leg(counter, start, end));
                startTime = end;
                counter++;
            }

            return legs;
        }
    }
}
