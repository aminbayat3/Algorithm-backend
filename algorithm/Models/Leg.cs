using algorithm.Models.Base;

namespace algorithm.Models
{
    public class Leg : Entity
    {
        public int Number { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Car> PluggedInCars { get; set; }
        public PlugInEvent PlugInEvent {  get; set; }
        public PlugOutEvent PlugOutEvent { get; set; } 
        public FulfilledEvent FulfillEvent { get; set; } // Need met
        public FullEvent FullEvent { get; set; } 

        public Leg(int number, DateTime startTime, DateTime endtime)
        {
            Number = number;
            StartTime = startTime;  
            EndTime = endtime;  
        }
    }
}
