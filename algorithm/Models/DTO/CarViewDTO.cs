using algorithm.Extensions;

namespace algorithm.Models.DTO
{
    public class CarViewDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double MaxAcConnectionLoad { get; set; }
        public double TankSize { get; set; }

        public CarViewDTO(Car car) { 
            Id = car.Id;
            Name = car.Name;
            MaxAcConnectionLoad = car.MaxAcConnectionLoad;
        }
    }
}
