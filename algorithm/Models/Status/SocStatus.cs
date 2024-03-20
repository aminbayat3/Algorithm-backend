using algorithm.Data;
using algorithm.Models.Base;

namespace algorithm.Models.Status
{
    public class SocStatus
    {
        public string CarId { get; set; }
        public double Soc { get; set; }

        public SocStatus(string carId)
        {
            Soc = 0;
            CarId = carId;
        }

        public override string ToString()
        {
            return $"CarId: {CarId}, Soc: {Soc}";
        }
    }
}
