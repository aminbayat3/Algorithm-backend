using algorithm.Models.Base;

namespace algorithm.Models.Status
{
    public class SocStatus
    {
        public string CarId { get; set; }
        public double Soc { get; set; }

        public SocStatus(double soc = 0, string carId = null)
        {
            Soc = soc;
            CarId = carId;
        }
    }
}
