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
        public List<string> calculateCarsDataSimulation(CarChargingSessionDTO form, Statuses statuses, int plugInCounter = 0, int plugOutCounter = 0, int needCounter = 0)
        {
            List<Event> pluginEvents = ReservationDb.getSortedPluginEvents(form.Reservations); // later we should have a Repo Class and inject Db class into it and move these methods into the Repo class not in the Db class
            List<Event> plugoutEvents = ReservationDb.getSortedPlugoutEvents(form.Reservations);
            List<CarEnergyRequirement> neededEnergies = ReservationDb.getSortedNeededEnergy(form.Reservations);

            for(int i = 0; i < statuses.SocLegs.Count; i++)
            {
               if(i > 0) statuses.SocLegs[i] = statuses.SocLegs[i - 1];

                if (statuses.SocLegs[i].EndTime >= pluginEvents[plugInCounter].Time)
                {
                    form.ConnectedCarIds.Add(pluginEvents[plugInCounter].CarId);
                    plugInCounter++;
                    break;
                }

                if (statuses.SocLegs[i].EndTime >= plugoutEvents[plugOutCounter].Time)
                {
                    form.ConnectedCarIds = form.ConnectedCarIds.Where(carId => carId != plugoutEvents[plugOutCounter].CarId).ToList();
                    plugOutCounter++;
                    break;

                }

                if(statuses.SocLegs[i].Soc )
            }

       
        }

        private void AddToReadyTimeList (List<string> readyTimeList, Leg leg)
        {
            readyTimeList.Add(leg.EndTime.ToString("yyyy.MM.dd HH:mm"));
        }
    }
}
