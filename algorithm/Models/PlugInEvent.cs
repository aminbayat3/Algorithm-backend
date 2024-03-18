using algorithm.Models.Base;

namespace algorithm.Models
{
    public class PlugInEvent: Event
    {
        public string WallBoxId { get; set; }
        public DateTime ExpectedPlugOutTime { get; set; }
    }
}
