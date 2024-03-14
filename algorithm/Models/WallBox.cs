using algorithm.Models.Base;

namespace algorithm.Models
{
    public class WallBox: Entity
    {
        public double AcLimit { get; set; } // KW
        public bool IsActive { get; set; } = true; // whether the wall box is active or not
    }
}
