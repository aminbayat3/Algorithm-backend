using algorithm.Data;
using algorithm.Models.DTO;
using algorithm.Models;
using algorithm.Utils;
using Microsoft.AspNetCore.Mvc;

namespace algorithm.Controllers
{
    [Route("api/Reservations")]
    [ApiController]
    public class ReservationController
    {
        [HttpGet]
        public List<ReservationDTO> GetReservations()
        {
            //get the data from the database
            var reservations = new List<ReservationDTO>(); 

            foreach(var reservation in ReservationDb.Reservations) 
            {
                reservations.Add(new ReservationDTO(reservation));
            }

            return reservations;
        }

        [HttpPost] //later we have to send the frontend (ReservationDTO) not Reservation type and we should use auto mapper for quick and clean conversion
        public List<Reservation> AddReservations([FromBody] List<ReservationDTO> reservationDTOs)
        {   
            var reservations = new List<Reservation>(); 
            
            foreach (var reservationDTO in reservationDTOs)
            {
                var reservation = new Reservation() 
                { 
                   Id = reservationDTO.Id,
                   CarId = reservationDTO.CarId,
                   Expi = reservationDTO.Expi,
                   Expo = reservationDTO.Expo,
                   NeededEnergy = reservationDTO.NeededEnergy,
                   Priority = reservationDTO.Priority,
                };

                reservations.Add (reservation);

            }

            ReservationDb.AddReservations(reservations);

            return reservations;
        }
    }
}
