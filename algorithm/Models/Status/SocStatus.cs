using algorithm.Models.Base;

namespace algorithm.Models.Status
{
    public class SocStatus
    {
        public string CarId { get; set; }
        public double Soc { get; set; }

        public SocStatus()
        {
            Soc = 0;
            CarId = null;
        }
    }
}
