using algorithm.Extensions;

namespace algorithm.Models.DTO
{
    public class CarViewDTO
    {
        public Guid? Id { get; set; } // for now the id should be nullable , but later it will be created in the database by default so in the future it shouldn't be a nullable property
        public string Name { get; set; }
        public double ConnectionLoad { get; set; }
        public double EnergyRequired { get; set; } // the need
        public double FullEnergy { get; set; }
        public DateTime PlugInTime { get; set; }
        public DateTime PlugOutTime { get; set; }
        public double MaxAcConnectionLoad { get; set; } // this should move to the infrastructure class
        public DateTime ExpectedReadyTime { get; set; } // this is the Full Time
        public double Soc { get; set; } // current state of the charge(it shows how much energy a car has at the moment)

        public CarViewDTO(Car car) { 
            Id = car.Id;
            Name = car.Name;
            ConnectionLoad = car.ConnectionLoad;
            EnergyRequired = car.EnergyRequired;
            FullEnergy = car.FullEnergy;
            PlugInTime = car.PlugInTime.MarkAsUtc();
            PlugOutTime = car.PlugOutTime.MarkAsUtc();
            ExpectedReadyTime = car.ExpectedReadyTime.MarkAsUtc();
            MaxAcConnectionLoad = car.MaxAcConnectionLoad;
            Soc = car.Soc;
        }
    }
}
