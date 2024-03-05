using algorithm.Models;
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
        public List<string> GetCarChargingStatus([FromQuery] CarsDTO CarsDTO)
        {
            var test = CarService.CalculateCarsReadyTimeUsingSimulation(CarsDTO.SortedEnergyRequired, CarsDTO.ConnectedLoad, CarsDTO.NumberOfCars, CarsDTO.PlugInTime, CarsDTO.intervalDurationInMinutes, CarsDTO.MaxChargeCapacity);
            return test;
        }
    }
}

