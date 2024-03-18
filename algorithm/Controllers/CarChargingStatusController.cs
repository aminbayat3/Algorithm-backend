using algorithm.Models.DTO;
using algorithm.Services;
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
            var test = ChargeManagementService.calculateCarsDataSimulation(form);
            return test;
        }
    }
}

