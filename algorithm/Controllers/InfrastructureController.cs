using algorithm.Data;
using algorithm.Models;
using algorithm.Models.DTO;
using algorithm.Models.DTO.Wallbox;
using Microsoft.AspNetCore.Mvc;

namespace algorithm.Controllers
{
    [Route("api/InfrastructureData")]
    [ApiController]
    public class InfrastructureController : ControllerBase
    {
        [HttpGet]
        public InfrastructureDTO GetInfrastructureData()
        {
            //get the data from the database
            var infrastructure = new InfrastructureDTO()
            {
                StartTime = InfrastructureDb.StartTime,
                EndTime = InfrastructureDb.EndTime,
                LegDuration = InfrastructureDb.LegDuration,
                ConnectionLoad = InfrastructureDb.ConnectionLoad,
                Wallboxes = InfrastructureDb.WallBoxes,
                Cars = InfrastructureDb.Cars,
            };

            return infrastructure;
        }

        [HttpPost]
        public InfrastructureDTO AddInfrastructureData([FromBody] InfrastructureDTO form)
        {
            var infrastructure = new Infrastructure()
            {
                StartTime = form.StartTime,
                EndTime = form.EndTime,
                LegDuration = form.LegDuration,
                ConnectionLoad = form.ConnectionLoad,
                Wallboxes = form.Wallboxes,
                Cars = form.Cars,
            };

            InfrastructureDb.AddConfiguration(infrastructure);

            return new InfrastructureDTO(infrastructure);
        }

        [HttpPut]
        public InfrastructureDTO UpdateInfrastructureData([FromBody] InfrastructureDTO form)
        {
            var infrastructure = new Infrastructure()
            {
                StartTime = form.StartTime,
                EndTime = form.EndTime,
                LegDuration = form.LegDuration,
                ConnectionLoad = form.ConnectionLoad,
                Wallboxes = form.Wallboxes,
                Cars = form.Cars,
            };

            InfrastructureDb.AddConfiguration(infrastructure);

            return new InfrastructureDTO(infrastructure);
        }
    }
}
//later when we use a database and entity framework
//we can use AddRange to add a list of reservations
//to the database at once instead of doing a for loop(it's more efficient)