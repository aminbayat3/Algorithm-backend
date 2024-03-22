using algorithm.Data;
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
                int ExpoLegNum = Helper.ConvertTimeToLegNumber(reservation.Expo);

                for (int i = legNum; i < ExpoLegNum; i++)
                {
                    foreach (WallBoxStatus status in statuses.SimulatePiAndPo[i].FutureWallBoxStatuses)
                    {
                        status.CarId = $"Car{Helper.GetNumericPart(status.WallBoxId)}";

                        if (Helper.GetNumericPart(status.WallBoxId) == Helper.GetNumericPart(reservation.CarId))
                        {
                            status.CarId = reservation.CarId;
                            status.IsConnected = true;
                            status.NeededEnergy = reservation.NeededEnergy;
                        }
                    }
                }

            }

            for (int legNumber = 0; legNumber < statuses.SocLegs.Count; legNumber++)
            {
                var notification = ChargeManagementService.legManager(statuses, legNumber);

                // notification
                Console.WriteLine("CommandToWB: " + notification.CommandToWB + "     " + "NotificationToUser: " + notification.NotificationToUser);
              

                // normal sleeping time is the package length
                Thread.Sleep(100);
            }



            Console.WriteLine("STARTTTT SOC !!!!!!!!!!!!!!!!!!!!______________________________________________________");
            var counter2 = 1;
            foreach (var SocStatus in statuses.SocLegs)
            {
                Console.WriteLine("LegNumber: " + counter2 + " StartTime: " + SocStatus.StartTime + " EndTime: " + SocStatus.EndTime);
                Console.WriteLine(SocStatus.ToString());
                counter2++;
            }

            ////Print where we can see if the injection was right or not
            //Console.WriteLine("STARTTTT WALLBoxxx !!!!!!!!!!!!!!!!!!!!______________________________________________________");
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


