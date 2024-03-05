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
            var readyTimeList = new List<string>();

            foreach (Interval interval in intervals)
            {
                if (j == numberOfCars)
                {
                    break;
                }

                // When the array contains two or more elements with the same energy value , i check if the total is already greater.
                if (total >= sortedEnergyRequired[j])
                {
                    AddToReadyTimeList(readyTimeList, interval);
                    k--;
                    j++;
                    continue;
                }

                total += (double)intervalDurationInMinutes / 60 * Math.Min(connectedLoad / k, maxChargeCapacity);
                interval.Energy = total;

                if (interval.Energy >= sortedEnergyRequired[j])
                {
                    AddToReadyTimeList(readyTimeList, interval);
                    k--;
                    j++;
                }
            }

            return readyTimeList;
        }

        private void AddToReadyTimeList (List<string> readyTimeList, Interval interval)
        {
            readyTimeList.Add(interval.End.ToString("yyyy.MM.dd HH:mm"));
        }
    }
}
