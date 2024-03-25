using algorithm.Data;
using algorithm.Models.Base;

namespace algorithm.Models.Status
{
    public class SocStatus
    {
        public string CarId { get; set; }
        public double Soc { get; set; }
        public bool IsFull { get; set; }
        public bool IsNeedMet {  get; set; }

        public SocStatus(string carId)
        {
            Soc = 0;
            CarId = carId;
            IsFull = false;
            IsNeedMet = false;
        }

        public override string ToString()
        {
            return $"CId: {CarId}, Soc: {Soc}, IsF?: {IsFull}, IsN?: {IsNeedMet}";
        }
    }
}
