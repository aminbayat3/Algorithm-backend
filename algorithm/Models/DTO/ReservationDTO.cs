namespace algorithm.Models.DTO
{
    public class ReservationDTO
    {
        public string Id { get; set; }  
        public string CarId { get; set; }
        public DateTime Expi { get; set; }
        public DateTime Expo { get; set; }
        public double NeededEnergy { get; set; }
        public int Priority { get; set; }

        public ReservationDTO(Reservation reservation)
        {
            Id = reservation.Id;
            CarId = reservation.CarId;
            Expi = reservation.Expi;
            Expo = reservation.Expo;
            NeededEnergy = reservation.NeededEnergy;
            Priority = reservation.Priority;
        }

    }
}
