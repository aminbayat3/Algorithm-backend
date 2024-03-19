namespace algorithm.Models
{
    public class Statuses
    {
        public List<StatusOfSocInCars> SocLegs { get; set; }
        public List<StatusOnWallBoxes> WallBoxLegs { get; set; }
        public List<AvailableConnectionLoad> ConnectionLoadLegs { get; set; }
        public List<FutureStatusOnWallBoxes> SimulatePiAndPo {  get; set; }

        public Statuses(List<StatusOfSocInCars> socLegs, List<StatusOnWallBoxes> wallBoxLegs, List<AvailableConnectionLoad> connectionLoadLegs, List<FutureStatusOnWallBoxes> simulatePiAndPo)
        {
            SocLegs = socLegs;
            WallBoxLegs = wallBoxLegs;
            ConnectionLoadLegs = connectionLoadLegs;
            SimulatePiAndPo = simulatePiAndPo;
        }
    }
}
