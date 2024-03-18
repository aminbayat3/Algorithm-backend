using algorithm.Models.Base;
using algorithm.Models.Status;

namespace algorithm.Models
{
    public class StatusOnWallBoxes: Leg
    {
        public List<WallBoxStatus> WallBoxStatuses { get; set; }

        public StatusOnWallBoxes(int number, DateTime startTime, DateTime endtime): base(number, startTime, endtime)
        {
            WallBoxStatuses = new List<WallBoxStatus>();
        }
    }
}
