using algorithm.Data;
using algorithm.Models;
using algorithm.Models.DTO;
using algorithm.Models.DTO.Wallbox;
using Microsoft.AspNetCore.Mvc;

namespace algorithm.Controllers
{
    [Route("api/Wallboxes")]
    [ApiController]
    public class WallboxController : ControllerBase
    {
        [HttpPost]
        public WallboxesViewDTO CreateWallboxesAsync([FromBody] List<WallboxDTO> wallboxDTOs)
        {
            //later we need to add validation and error handling
            var wallboxEntities = wallboxDTOs.Select(dto => new WallBox
            {
                Id = dto.Id,
                Name = dto.Name,
                AcLimit = dto.AcLimit
            }).ToList();

            //later this should be an asynchronous and we have to use a try and catch method 
            WallBoxDb.AddWallboxes(wallboxEntities);

            return new WallboxesViewDTO(wallboxEntities);
        }
    }
}
//later when we use a database and entity framework
//we can use AddRange to add a list of reservations
//to the database at once instead of doing a for loop(it's more efficient)