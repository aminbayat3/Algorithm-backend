using algorithm.Data;
using algorithm.Models;
using algorithm.Models.Base;
using algorithm.Models.DTO;
using algorithm.Utils;
using System;

namespace algorithm.Services
{
    public class ChargeManagementService 
    {
        public List<string> calculateCarsDataSimulation(CarChargingSessionDTO form)
        {
            List<SocLeg> socLegs = LegGenerator.GenerateSocLegs(form.StartTime, form.EndTime, form.LegDuration, CarDb.Cars);
            List<WallBoxLeg> wallboxLegs = LegGenerator.GenerateWallBoxLegs(form.StartTime, form.EndTime, form.LegDuration, WallBoxDb.WallBoxes);

            int plugInCounter = 0;
            int plugOutCounter = 0;
            int fulfilledCounter = 0;

            int counter = 0;

            for(int i = 0; i < socLegs.Count; i++)
            {
                if (wallboxLegs[i].EndTime >= form.PlugInEvents[plugInCounter].Time)
                {
                    wallboxLegs[i].IsConnected = true;
                    wallboxLegs[i].
                    form.ConnectedCarIds.Add(form.PlugInEvents[plugInCounter].CarId);
                    plugInCounter++;
                    break;
                }

                if (wallboxLegs[i].EndTime >= form.PlugOutEvents[plugOutCounter].Time)
                {
                    form.ConnectedCarIds = form.ConnectedCarIds.Where(carId => carId != form.PlugOutEvents[plugOutCounter].CarId).ToList();

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

        private void AddToReadyTimeList (List<string> readyTimeList, Leg leg)
        {
            readyTimeList.Add(leg.EndTime.ToString("yyyy.MM.dd HH:mm"));
        }
    }
}
