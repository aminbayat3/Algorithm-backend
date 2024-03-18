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
        public List<string> calculateCarsDataSimulation(CarChargingSessionDTO form, Statuses statuses, List<Event> pluginEvents, List<Event> plugoutEvents, List<CarEnergyRequirement> neededEnergies, int legNumber, int plugInCounter = 0, int plugOutCounter = 0, int needCounter = 0)
        {
                var needMetCar = statuses.SocLegs[legNumber].SocStatuses.FirstOrDefault(status => status.Soc >= neededEnergies[needCounter].NeededEnergy)?.CarId;

               if (legNumber > 0) statuses.SocLegs[legNumber].SocStatuses = statuses.SocLegs[legNumber - 1].SocStatuses;

                if (statuses.SocLegs[legNumber].EndTime >= pluginEvents[plugInCounter].Time)
                {
                    form.ConnectedCarIds.Add(pluginEvents[plugInCounter].CarId);
                    var statusOnWallBoxes = new StatusOnWallBoxes(legNumber, statuses.SocLegs[legNumber].StartTime, statuses.SocLegs[legNumber].EndTime);
                    statusOnWallBoxes.WallBoxStatuses
                    plugInCounter++;
                    return 
                }

                if (statuses.SocLegs[legNumber].EndTime >= plugoutEvents[plugOutCounter].Time)
                {
                    form.ConnectedCarIds = form.ConnectedCarIds.Where(carId => carId != plugoutEvents[plugOutCounter].CarId).ToList();
                    plugOutCounter++;
                    return 
                }
                
                if (needMetCar != null)
                {

                }
       
        }

        private void AddToReadyTimeList (List<string> readyTimeList, Leg leg)
        {
            readyTimeList.Add(leg.EndTime.ToString("yyyy.MM.dd HH:mm"));
        }
    }
}
