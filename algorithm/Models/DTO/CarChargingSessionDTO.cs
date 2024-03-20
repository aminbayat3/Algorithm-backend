using algorithm.Models.Base;

namespace algorithm.Models.DTO
{
    public class CarChargingSessionDTO
    {
        //public List<Reservation> Reservations {  get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int LegDuration { get; set; } = 15; // Minutes
        public double ConnectionLoad {  get; set; }
    }
}
