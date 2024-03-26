using algorithm.Models.Base;

namespace algorithm.Models
{
    public class ConnectionLoad: Entity
    {
        public DateTime Time { get; set; }  
        public double Value { get; set; }
    }
}
