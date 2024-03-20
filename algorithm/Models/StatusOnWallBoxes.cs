using algorithm.Data;
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

            foreach (var wallbox in WallBoxDb.WallBoxes)
            {
                WallBoxStatuses.Add(new WallBoxStatus(wallbox.Id));
            }
        }

        public override string ToString()
        {
            string result = "FutureWallBoxStatuses: \n";
            foreach (WallBoxStatus status in WallBoxStatuses)
            {
                result += status.ToString() + "\n";
            }
            return result;
        }
    }
}
