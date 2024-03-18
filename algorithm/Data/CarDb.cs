using algorithm.Models;

namespace algorithm.Data
{
    public static class CarDb
    {
        public static List<Car> Cars { get; } = new List<Car>()
        {
            new Car { Id = "Car1", Name = "Car1", TankSize = 10, MaxAcConnectionLoad = 5},
            new Car { Id = "Car2", Name = "Car2", TankSize = 10, MaxAcConnectionLoad = 7.5},
            new Car { Id = "Car3", Name = "Car3", TankSize = 30, MaxAcConnectionLoad = 11},
            new Car { Id = "Car4", Name = "Car4", TankSize = 40, MaxAcConnectionLoad = 11},
        };
    }
}
