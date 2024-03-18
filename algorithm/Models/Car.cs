using algorithm.Models.Base;

namespace algorithm.Models
{
    public class Car : Entity
    {
        public string Name { get; set; }    
        public double TankSize { get; set; } = 0;
        public double MaxAcConnectionLoad { get; set; }
    }
}