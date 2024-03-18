using algorithm.Models.Status;

namespace algorithm.Models
{
    public class FutureStatusOnWallBoxes
    {
       public List<FutureWallBoxStatus> FutureWallBoxStatuses { get; set; }

        public FutureStatusOnWallBoxes() {
            FutureWallBoxStatuses = new List<FutureWallBoxStatus>();    
        }
    }
}
