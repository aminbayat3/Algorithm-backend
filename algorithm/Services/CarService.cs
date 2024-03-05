using algorithm.Utils;
using System;

namespace algorithm.Services
{
    public class CarService 
    {
        public List<string> CalculateCarsReadyTimeUsingSimulation(List<double> sortedEnergyRequired, double connectedLoad, int numberOfCars, DateTime plugInTime, int intervalDurationInMinutes, double maxChargeCapacity)
        {
            List<Interval> intervals = TimeIntervalGenerator.GenerateWeeklyTimestamps(plugInTime, intervalDurationInMinutes);
            int j = 0;
            int k = numberOfCars;
            double total = 0;
            var readyTimeArray = new List<string>();

            foreach (Interval interval in intervals)
            {
                if (j == numberOfCars)
                {
                    break;
                }

                if (total >= sortedEnergyRequired[j])
                {
                    readyTimeArray.Add(interval.End.ToString("yyyy.MM.dd HH:mm"));
                    k--;
                    j++;
                    continue;
                }

                total += (double)intervalDurationInMinutes / 60 * Math.Min(connectedLoad / k, maxChargeCapacity);
                interval.Energy = total;

                if (interval.Energy >= sortedEnergyRequired[j])
                {
                    readyTimeArray.Add(interval.End.ToString("yyyy.MM.dd HH:mm"));
                    k--;
                    j++;
                }
            }

            return readyTimeArray;
        }
    }
}
