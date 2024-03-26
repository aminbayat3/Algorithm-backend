using algorithm.Models;
using algorithm.Models.DTO;
using System.Runtime.CompilerServices;

namespace algorithm.Data
{
    public static class InfrastructureDb
    {
        public static DateTime StartTime { get; set; }
        public static DateTime EndTime { get; set; }
        public static double LegDuration { get; set; } = 15; // Minutes
        public static double ConnectionLoad { get; set; }
        public static List<WallBox> WallBoxes { get; set; } = new List<WallBox>() {
            //new WallBox { Id = "WB1", Name="WB 1" AcLimit = 11, IsActive = true },
            //new WallBox { Id = "WB2", Name="WB 2", AcLimit = 11, IsActive = true },   
            //new WallBox { Id = "WB3", Name="WB 3", AcLimit = 11, IsActive = true },    
            //new WallBox { Id = "WB4", Name="WB 4", AcLimit = 11, IsActive = true },
        };
        public static List<Car> Cars { get; set; } = new List<Car>() { 
            //new Car { Id = "Car1", Name = "Car1", TankSize = 20, MaxAcConnectionLoad = 12},
            //new Car { Id = "Car2", Name = "Car 2", TankSize = 50, MaxAcConnectionLoad = 12},
            //new Car { Id = "Car3", Name = "Car3", TankSize = 20, MaxAcConnectionLoad = 12},
            //new Car { Id = "Car4", Name = "Car 4", TankSize = 20, MaxAcConnectionLoad = 12},
        };

        public static void AddConfiguration(Infrastructure infrastructure)
        {
            StartTime = infrastructure.StartTime;
            EndTime = infrastructure.EndTime;
            LegDuration = infrastructure.LegDuration;
            ConnectionLoad = infrastructure.ConnectionLoad;
            WallBoxes = infrastructure.Wallboxes;
            Cars = infrastructure.Cars;
        }
    }
}
