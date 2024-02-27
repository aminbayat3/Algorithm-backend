using algorithm.Models;
using algorithm.Services;
using Microsoft.AspNetCore.Mvc;

namespace algorithm.Controllers
{
    [Route("api/CarChargingStatus")]
    [ApiController]
    public class CarChargingStatusController : ControllerBase
    {
         private CarService CarService {  get; }

        public CarChargingStatusController(CarService carService)
        {
            CarService = carService;
        }

        [HttpGet]
        public List<double> GetCarChargingStatus([FromQuery] CarsDTO CarsDTO)
        {
            var test = CarService.CalculateCarsReadyTime(CarsDTO.SortedEnergyRequired, CarsDTO.ConnectedLoad, CarsDTO.NumberOfCars, CarsDTO.HoursToFullCharge, CarsDTO.ExpectedReadyTimes, CarsDTO.MaxChargeCapacity);
            return new List<double> {  };
        }
    }
}
