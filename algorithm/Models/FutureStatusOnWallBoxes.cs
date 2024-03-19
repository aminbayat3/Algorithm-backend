using algorithm.Data;
using algorithm.Models.Base;
using algorithm.Models.DTO;
using algorithm.Models.Status;
using Microsoft.AspNetCore.Http;

namespace algorithm.Models
{
    public class FutureStatusOnWallBoxes: Leg
    {
       public List<FutureWallBoxStatus> FutureWallBoxStatuses { get; set; } // change the nam to SimulatePluginAndPlugOut

        public FutureStatusOnWallBoxes(int number, DateTime startTime, DateTime endtime) : base(number, startTime, endtime)
        {
            FutureWallBoxStatuses = new List<FutureWallBoxStatus>();

            foreach (var wallbox in WallBoxDb.WallBoxes)
            {
                FutureWallBoxStatuses.Add(new FutureWallBoxStatus(wallbox.Id));
            }
        }

        public override string ToString()
        {
            string result = "FutureWallBoxStatuses: \n";
            foreach (FutureWallBoxStatus status in FutureWallBoxStatuses)
            {
                result += status.ToString() + "\n";
            }
            return result;
        }
    }
}
