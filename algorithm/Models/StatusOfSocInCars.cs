using algorithm.Models.Base;
using algorithm.Models.Status;

namespace algorithm.Models
{
    public class StatusOfSocInCars: Leg
    {
        public List<SocStatus> SocStatuses { get; set; }
        public StatusOfSocInCars(int number, DateTime startTime, DateTime endTime): base(number, startTime, endTime)
        {
          SocStatuses = new List<SocStatus>();
        }
    }
}
 