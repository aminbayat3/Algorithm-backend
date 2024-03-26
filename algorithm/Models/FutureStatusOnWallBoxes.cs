using algorithm.Data;
using algorithm.Models.Base;
using algorithm.Models.Status;

namespace algorithm.Models
{
    public class FutureStatusOnWallBoxes : Leg
    {
        public List<WallBoxStatus> FutureWallBoxStatuses { get; set; } // change the nam to SimulatePluginAndPlugOut

        public FutureStatusOnWallBoxes(int number, DateTime startTime, DateTime endtime) : base(number, startTime, endtime)
        {
            FutureWallBoxStatuses = new List<WallBoxStatus>();

            foreach (var wallbox in InfrastructureDb.WallBoxes)
            {
                FutureWallBoxStatuses.Add(new WallBoxStatus(wallbox.Id));
            }
        }

        public override string ToString()
        {
            string result = "FutureWallBoxStatuses: \n";
            foreach (WallBoxStatus status in FutureWallBoxStatuses)
            {
                result += status.ToString() + "\n";
            }
            return result;
        }
    }
}
