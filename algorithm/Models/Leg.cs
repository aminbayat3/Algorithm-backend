using algorithm.Models.Base;

namespace algorithm.Models
{
    public class Leg : Entity
    {
        public int Number { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double CalculatedChargeLoad { get; set; }
        public PlugInEvent PlugIn {  get; set; }
        public PlugOutEvent PlugOut { get; set; } 
        public FulfilledEvent Fulfill { get; set; }
        public FullEvent Full { get; set; } 

        public Leg(int number, DateTime startTime, DateTime endtime)
        {
            Number = number;
            StartTime = startTime;  
            EndTime = endtime;  
        }
    }
}
