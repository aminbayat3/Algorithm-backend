using algorithm.Data;
using algorithm.Models;
using algorithm.Models.Base;
using algorithm.Models.DTO;
using algorithm.Models.Status;
using algorithm.Utils;
using System;

namespace algorithm.Services
{
    public class ChargeManagementService 
    {
        public List<string> calculateCarsDataSimulation(CarChargingSessionDTO form, Statuses statuses, int legNumber) // it should check if we have any plugin before this 
        {

            var pluginEvent = ReadDataAndUpdateWallboxesStatuses(form, legNumber);

           

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

        private Event ReadDataAndUpdateWallboxesStatuses(CarChargingSessionDTO form, Statuses statuses, int legNumber)
        {
            //Finding the Current Leg
            Leg currentLeg = ConvertLegNumberToPackageTime(form, legNumber);

            //Reading Data
            List<Event> pluginEvents = ReservationDb.getSortedPluginEvents(ReservationDb.Reservations);
            List<Event> plugoutEvents = ReservationDb.getSortedPlugoutEvents(ReservationDb.Reservations);
            List<CarEnergyRequirement> neededEnergies = ReservationDb.getSortedNeededEnergy(ReservationDb.Reservations);

            //Updating The Status of WB of the Current Leg (later we can seperate these parts into their own method)
            Event pluginEvent = pluginEvents.FirstOrDefault(e => !e.IsPlugIn && currentLeg.EndTime >= e.Time);

            if(pluginEvent != null)
            {
                pluginEvent.IsPlugIn = true;
                form.ConnectedCarIds.Add(pluginEvent.CarId);
                connectedCar = CarDb.Cars.FirstOrDefault(car => car.Id == pluginEvent.CarId)

                foreach(WallBoxStatus status in statuses.WallBoxLegs[legNumber].WallBoxStatuses) 
                {
                    if(status.CarId == pluginEvent.CarId)
                    {
                        status.IsConnected = true;
                        status.CurrentChargeLoad = (form.ConnectionLoad / form.ConnectedCarIds.Count;
                    }
                }
                // how can i update 
            }
        }
        private Leg ConvertLegNumberToPackageTime(CarChargingSessionDTO form, int legNumber)
        {
            DateTime startTime = form.StartTime.AddMinutes(form.LegDuration * (legNumber - 1));
            DateTime endTime = startTime.AddMinutes(form.LegDuration);

            return new Leg(legNumber, startTime, endTime);
        }
    }
}
