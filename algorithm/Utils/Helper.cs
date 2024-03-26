using algorithm.Data;

namespace algorithm.Utils
{
    public static class Helper
    {
         public static int ConvertTimeToLegNumber(DateTime time)
        {
            TimeSpan duration = time - InfrastructureDb.StartTime;

            //Calculate the total number of minutes in a TimeSpan
            double totalMinutes = duration.TotalMinutes;

            // Divide by 15 to find how many 15-minute intervals are contained in the duration

            return (int)Math.Floor(totalMinutes / InfrastructureDb.LegDuration);
        }

        public static int GetNumericPart(string input)
        {
            // Find the index where the first digit appears
            int index = 0;
            while (index < input.Length && !char.IsDigit(input[index]))
            {
                index++;
            }

            // Extract the numeric part of the string
            string numericPart = input.Substring(index);

            // Convert the numeric part to an integer using int.Parse
            return int.Parse(numericPart);
        }

    }
}
