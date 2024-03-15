using algorithm.Extensions;

namespace algorithm.Models.DTO
{
    public class CarViewDTO
    {
        public Guid? Id { get; set; } // for now the id should be nullable , but later it will be created in the database by default so in the future it shouldn't be a nullable property
        public string Name { get; set; }
        public double FullEnergy { get; set; }
        public DateTime ExpectedReadyTime { get; set; }
        public double MaxAcConnectionLoad { get; set; }
        public double? TankSize { get; set; }
        public double Soc { get; set; } // current state of the charge(it shows how much energy a car has at the moment)

        public CarViewDTO(Car car) { 
            Id = car.Id;
            Name = car.Name;
            FullEnergy = car.FullEnergy;
            ExpectedReadyTime = car.ExpectedReadyTime.MarkAsUtc();
            MaxAcConnectionLoad = car.MaxAcConnectionLoad;
            Soc = car.Soc;
        }
    }
}
