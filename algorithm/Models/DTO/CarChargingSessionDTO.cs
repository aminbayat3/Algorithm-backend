namespace algorithm.Models.DTO
{
    public class CarChargingSessionDTO
    {
        public List<PlugInEvent> PlugInEvents { get; set; }
        public List<PlugOutEvent> PlugOutEvents { get; set; }
        public List<FulfilledEvent> FulfilledEvents { get; set; }   
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int IntervalDuration { get; set; } = 15; // Minutes
        public List<Car> ConnectedCars { get; set; } 
        public double ConnectionLoad {  get; set; }
    }
}
