using algorithm.Models.DTO;
using algorithm.Services;
using Microsoft.AspNetCore.Mvc;

namespace algorithm.Controllers
{
    [Route("api/CarChargingStatus")]
    [ApiController]
    public class CarChargingStatusController : ControllerBase
    {
         private CarService CarService { get; set; } 

        public CarChargingStatusController(CarService carService)
        {
            CarService = carService;
        }

        [HttpGet]
        public List<string> GetCarChargingStatus([FromQuery] CarChargingSessionDTO form)
        {
            var test = CarService.calculateCarsDataSimulation(form);
            return test;
        }
    }
}

