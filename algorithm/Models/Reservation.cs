using algorithm.Models.Base;

namespace algorithm.Models
{
    public class Reservation: Entity
    {
        public string CarId { get; set; }
        public DateTime Expi {  get; set; }
        public DateTime Expo { get; set; }
        public double NeededEnergy { get; set; }
        public int Priority { get; set; }
    }
}
