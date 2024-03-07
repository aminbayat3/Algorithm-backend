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
        public List<string> GetCarChargingStatus([FromQuery] CarFormDTO form)
        {
            var test = CarService.CalculateCarsReadyTimeUsingSimulation(form.SortedEnergyRequired, CarsDTO.ConnectedLoad, CarsDTO.NumberOfCars, CarsDTO.PlugInTime, CarsDTO.IntervalDurationInMinutes, CarsDTO.MaxChargeCapacity);
            return test;
        }
    }
}

