using algorithm.Data;
using algorithm.Models.Base;

namespace algorithm.Models.Status
{
    public class SocStatus
    {
        public string CarId { get; set; }
        public double Soc { get; set; }
        public bool IsFull { get; set; }

        public SocStatus(string carId)
        {
            Soc = 0;
            CarId = carId;
            IsFull = false;
        }

        public override string ToString()
        {
            return $"CarId: {CarId}, Soc: {Soc}";
        }
    }
}
