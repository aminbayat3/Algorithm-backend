﻿using algorithm.Data;
using algorithm.Models;
using algorithm.Models.DTO;
using algorithm.Models.DTO.Wallbox;
using algorithm.Utils;
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
                ConnectionLoads = InfrastructureDb.ConnectionLoads,
                Wallboxes = InfrastructureDb.WallBoxes,
                Cars = InfrastructureDb.Cars,
            };

            return infrastructure;
        }

        [HttpPost] //csv
        public InfrastructureDTO AddInfrastructureData([FromBody] InfrastructureDTO form)
        {
            var infrastructure = new Infrastructure()
            {
                StartTime = form.StartTime,
                EndTime = form.EndTime,
                LegDuration = form.LegDuration,
                ConnectionLoads = form.ConnectionLoads,
                Wallboxes = form.Wallboxes,
                Cars = form.Cars,
                Statuses = LegGenerator.GenerateLegs(form.StartTime, form.EndTime, form.LegDuration)
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
                ConnectionLoads = form.ConnectionLoads,
                Wallboxes = form.Wallboxes,
                Cars = form.Cars,
                Statuses = LegGenerator.GenerateLegs(form.StartTime, form.EndTime, form.LegDuration)
            };

            InfrastructureDb.AddConfiguration(infrastructure);

            UpdateConnectionLoadLegs(InfrastructureDb.Statuses, form.ConnectionLoads);

            return new InfrastructureDTO(infrastructure);
        }

        private void UpdateConnectionLoadLegs(Statuses statuses, List<ConnectionLoad> connectionLoads)
        {
            foreach (var connectionLoad in connectionLoads)
            {
                int legNumber = Helper.ConvertTimeToLegNumber(connectionLoad.Time);
                if(legNumber < statuses.SocLegs.Count) statuses.ConnectionLoadLegs[legNumber].ConnectionLoad = connectionLoad.Value;
            }
            
        }
    }
}
//later when we use a database and entity framework
//we can use AddRange to add a list of reservations
//to the database at once instead of doing a for loop(it's more efficient)