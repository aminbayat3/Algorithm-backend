using algorithm.Extensions;

namespace algorithm.Models.DTO
{
    public class CarViewDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double FullEnergy { get; set; }
        public DateTime ExpectedReadyTime { get; set; }
        public double MaxAcConnectionLoad { get; set; }
        public double TankSize { get; set; }
        public double Soc { get; set; } // current state of the charge(it shows how much energy a car has at the moment)

        public CarViewDTO(Car car) { 
            Id = car.Id;
            Name = car.Name;
            MaxAcConnectionLoad = car.MaxAcConnectionLoad;
        }
    }
}
