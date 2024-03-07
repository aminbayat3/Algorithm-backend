using algorithm.Models.Base;

namespace algorithm.Models
{
    public class Car : Entity
    {
        public string Name { get; set; }    
        public double ConnectionLoad { get; set; }
        public double EnergyRequired { get; set; } // the need
        public double FullEnergy { get; set; }
        public DateTime PlugInTime { get; set; }
        public DateTime PlugOutTime { get; set; }
        public double MaxAcConnectionLoad { get; set; } // this should move to the infrastructure class
        public DateTime ExpectedReadyTime { get; set; } // this is the Full Time
        public double Soc { get; set; } 
    }
}
