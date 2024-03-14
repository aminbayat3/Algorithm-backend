using algorithm.Models.Base;

namespace algorithm.Models
{
    public class PlugInEvent: Event
    { 
        public List<Car> PluggedInCars { get; set; }
        public DateTime ExpectedPlugOutTime { get; set; }
    }
}
