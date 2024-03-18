namespace algorithm.Models
{
    public class Statuses
    {
        public List<StatusOfSocInCars> SocLegs { get; set; }
        public List<StatusOnWallBoxes> WallBoxLegs { get; set; }
        public List<AvailableConnectionLoad> ConnectionLoadLegs { get; set; }

        public Statuses(List<StatusOfSocInCars> socLegs, List<StatusOnWallBoxes> wallBoxLegs, List<AvailableConnectionLoad> connectionLoadLegs)
        {
            SocLegs = socLegs;
            WallBoxLegs = wallBoxLegs;
            ConnectionLoadLegs = connectionLoadLegs;
        }
    }
}
