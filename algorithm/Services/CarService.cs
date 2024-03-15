using algorithm.Models;
using algorithm.Models.DTO;
using algorithm.Utils;
using System;

namespace algorithm.Services
{
    public class CarService 
    {
        public List<string> calculateCarsDataSimulation(CarChargingSessionDTO form)
        {
            List<Leg> legs = LegGenerator.GenerateTwoDayTimestamps(form.StartTime, form.EndTime, form.IntervalDuration);

            int plugInCounter = 0;
            int plugOutCounter = 0;
            int fulfilledCounter = 0;

            int counter = 0;

            for(int i = 0; i < legs.Count; i++)
            {
                if (legs[i].EndTime >= form.PlugInEvents[plugInCounter].Time)
                {
                    form.ConnectedCars.Add(form.PlugInEvents[plugInCounter].Car);
                    plugInCounter++;
                    break;
                }

                if (legs[i].EndTime >= form.PlugOutEvents[plugOutCounter].Time)
                {
                    form.ConnectedCars = form.ConnectedCars.Where(car => car.Name != form.PlugOutEvents[plugOutCounter].Car.Name).ToList();

                }
            }

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
