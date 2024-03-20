﻿using algorithm.Data;
using algorithm.Models;
using algorithm.Models.Base;
using algorithm.Models.DTO;
using algorithm.Models.Status;
using algorithm.Services.ChargeManagementService;
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
        public void GetCarChargingStatus([FromQuery] CarChargingSessionDTO form)
        {
            //ReservationDb.AddReservations(form.Reservations);

            Globals.Form = form;

            Statuses statuses = LegGenerator.GenerateLegs(form.StartTime, form.EndTime, form.LegDuration);

            // we have to inject the simulation layer based on the reservations in the form(pI and Po and Needed Energy)
            foreach (Reservation reservation in ReservationDb.Reservations)
            {

                int legNum = Helper.ConvertTimeToLegNumber(reservation.Expi); // this Helper Class later should be injected to this class . so later this shouldn't be a static class 

                foreach (WallBoxStatus status in statuses.SimulatePiAndPo[legNum].FutureWallBoxStatuses)
                {
                    if (Helper.GetNumericPart(status.WallBoxId) == Helper.GetNumericPart(reservation.CarId))
                    {
                        status.CarId = reservation.CarId;
                        status.IsConnected = true;
                        status.NeededEnergy = reservation.NeededEnergy;
                    }
                }

            }

            for (int legNumber = 0; legNumber < statuses.SocLegs.Count; legNumber++)
            {
                ChargeManagementService.legManager(statuses, legNumber);

                // normal sleeping time is the package length
                Thread.Sleep(1000);
            }

            // Print where we can see if the injection was right or not
            //var counter = 1;
            //foreach (var statusOnWB in statuses.SimulatePiAndPo)
            //{
            //    Console.WriteLine("counter: " + counter + " StartTime: " + statusOnWB.StartTime + " EndTime: " + statusOnWB.EndTime);
            //    Console.WriteLine(statusOnWB.ToString());
            //    counter++;
            //}


        }
    }
}


