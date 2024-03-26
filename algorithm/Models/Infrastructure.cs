namespace algorithm.Models
{
    public class Infrastructure
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double LegDuration { get; set; } = 15; // Minutes
        public double ConnectionLoad { get; set; }
        public List<WallBox> Wallboxes { get; set; }
        public List<Car> Cars { get; set; } 

    }
}
