using algorithm.Data;
using algorithm.Models;
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

            var test = ChargeManagementService.calculateCarsDataSimulation(form, statuses);
            return test;
        }
    }
}

