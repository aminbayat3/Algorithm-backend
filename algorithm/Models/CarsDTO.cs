namespace algorithm.Models
{
    public class CarsDTO
    {  
        public List<double> SortedEnergyRequired { get; set; }
        public List<double> ExpectedReadyTimes { get; set; }
        public double ConnectedLoad { get; set; }
        public double MaxChargeCapacity { get; set; }
        public int NumberOfCars { get; set; }
        public double HoursToFullCharge { get; set; }
    }
}
