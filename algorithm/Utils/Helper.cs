using algorithm.Data;

namespace algorithm.Utils
{
    public class Helper
    {
         public int ConvertTimeToLegNumber(DateTime time)
        {
            TimeSpan duration = time - Globals.Form.StartTime;

            //Calculate the total number of minutes in a TimeSpan
            double totalMinutes = duration.TotalMinutes;

            // Divide by 15 to find how many 15-minute intervals are contained in the duration

            return (int)Math.Floor(totalMinutes / Globals.Form.LegDuration);
        }

    }
}
