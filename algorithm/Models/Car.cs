using algorithm.Models.Base;

namespace algorithm.Models
{
    public class Car : Entity
    {
        public string Name { get; set; }    
        public double FullEnergy { get; set; } 
        public DateTime ExpectedReadyTime { get; set; } // this is related to the reservation class
        public double? TankSize { get; set; }
        public double MaxAcConnectionLoad { get; set; }
        public double Soc { get; set; } = 0;
    }
}