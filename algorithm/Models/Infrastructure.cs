

namespace algorithm.Models
{
    public class Infrastructure
    {
        public double ConnectionLoad { get; set; } 
        public List<WallBox> Wallboxes { get; set; }
        public List<Guid> PermittedCarIds { get; set; }
        public List<SocLeg> SocLegs { get; set; }
        public List<WallBoxLeg> WallBoxLegs { get; set; }
    }
}
