

namespace algorithm.Models.DTO
{
    public class InfrastructureDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double LegDuration { get; set; } = 15; // Minutes
        public List<ConnectionLoad> ConnectionLoads { get; set; }
        public List<WallBox> Wallboxes { get; set; }
        public List<Car> Cars { get; set; }

        public InfrastructureDTO() { }

        public InfrastructureDTO(Infrastructure infrastructure) 
        { 
            StartTime = infrastructure.StartTime;
            EndTime = infrastructure.EndTime;
            LegDuration = infrastructure.LegDuration;
            ConnectionLoads = infrastructure.ConnectionLoads;
            Wallboxes = infrastructure.Wallboxes;
            Cars = infrastructure.Cars;
        }
    }
}
