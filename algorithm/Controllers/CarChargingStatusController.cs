using algorithm.Data;
using algorithm.Models;
using algorithm.Models.Base;
using algorithm.Models.DTO;
using algorithm.Services;
using algorithm.Utils;
using Microsoft.AspNetCore.Mvc;

namespace algorithm.Controllers
{
    [Route("api/CarChargingStatus")]
    [ApiController]
    public class CarChargingStatusController : ControllerBase
    {
         private ChargeManagementService ChargeManagementService { get; set; } 

        public CarChargingStatusController(ChargeManagementService chargeManagementService)
        {
            ChargeManagementService = chargeManagementService;
        }

        [HttpGet]
        public List<string> GetCarChargingStatus([FromQuery] CarChargingSessionDTO form)
        {
            ReservationDb.AddReservations(form.Reservations);
            Statuses statuses = LegGenerator.GenerateLegs(form.StartTime, form.EndTime, form.LegDuration);

            List<Event> pluginEvents = ReservationDb.getSortedPluginEvents(form.Reservations); // later we should have a Repo Class and inject Db class into it and move these methods into the Repo class not in the Db class
            List<Event> plugoutEvents = ReservationDb.getSortedPlugoutEvents(form.Reservations);
            List<CarEnergyRequirement> neededEnergies = ReservationDb.getSortedNeededEnergy(form.Reservations);

            for (int legNumber = 0; legNumber < statuses.SocLegs.Count; legNumber++)
            {
                ChargeManagementService.calculateCarsDataSimulation(form, statuses, pluginEvents, plugoutEvents, neededEnergies, legNumber);
            }
    
        }
    }
}

