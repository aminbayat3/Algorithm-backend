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
        public List<string> legManager(Statuses statuses, int legNumber) // it should check if we have any plugin before this 
        {
            // first update the wallbox status
            ReadDataAndUpdateWallboxesStatuses(statuses, legNumber);

           

            //var needMetCar = statuses.SocLegs[legNumber].SocStatuses.FirstOrDefault(status => status.Soc >= neededEnergies[needCounter].NeededEnergy)?.CarId;
       
        }

        private void ReadDataAndUpdateWallboxesStatuses(Statuses statuses, int legNumber)
        {
            //Finding the Current Leg
            // Leg currentLeg = ConvertLegNumberToPackageTime(legNumber);

            //Reading Data
            List<Event> pluginEvents = ReservationDb.getSortedPluginEvents(ReservationDb.Reservations);
            List<Event> plugoutEvents = ReservationDb.getSortedPlugoutEvents(ReservationDb.Reservations);
            List<CarEnergyRequirement> neededEnergies = ReservationDb.getSortedNeededEnergy(ReservationDb.Reservations);

            //Updating The Status of WB of the Current Leg (later we can seperate these parts into their own method)
            Event pluginEvent = pluginEvents.FirstOrDefault(e => currentLeg.EndTime >= e.Time); // the plugin Time should be between the start and the end

            if(pluginEvent != null)
            {
                Car connectedCar = CarDb.Cars.FirstOrDefault(car => car.Id == pluginEvent.CarId);
               // form.ConnectedCars.Add(connectedCar);

                foreach(WallBoxStatus status in statuses.WallBoxLegs[legNumber].WallBoxStatuses) 
                {
                    
                    if(status.CarId == pluginEvent.CarId)
                    {
                        status.IsConnected = true;
                        status.CurrentChargeLoad = Math.Min((form.ConnectionLoad / form.ConnectedCars.Count), connectedCar.MaxAcConnectionLoad);
                    }
                }
                // how can i update 
            }
        }
        private Leg ConvertLegNumberToPackageTime(int legNumber)
        {
            DateTime startTime = StartTime.AddMinutes(LegDuration * (legNumber - 1));
            DateTime endTime = startTime.AddMinutes(LegDuration);

            return new Leg(legNumber, startTime, endTime);
        }
    }
}
