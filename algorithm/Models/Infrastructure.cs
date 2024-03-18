

namespace algorithm.Models
{
    public class Infrastructure
    {
        public double ConnectionLoad { get; set; }
        public List<WallBox> Wallboxes { get; set; }
        //public List<Guid> PermittedCarIds { get; set; } // let's ignore this for now
        public List<StatusOfSocInCars> SocLegs { get; set; }
        public List<StatusOnWallBoxes> WallBoxLegs { get; set; }
    }
}
