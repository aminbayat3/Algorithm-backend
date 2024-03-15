using algorithm.Models.Base;

namespace algorithm.Models
{
    public class PlugInEvent: Event
    {
        public DateTime ExpectedPlugOutTime { get; set; }
    }
}
