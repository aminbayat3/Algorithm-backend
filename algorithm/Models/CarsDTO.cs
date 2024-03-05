namespace algorithm.Models
{
    public class CarsDTO
    {  
        public List<double>? SortedEnergyRequired { get; set; }
        public double ConnectedLoad { get; set; }
        public DateTime PlugInTime { get; set; }
        public int intervalDurationInMinutes { get; set; }
        public double MaxChargeCapacity { get; set; }
        public int NumberOfCars { get; set; }
    }
}
