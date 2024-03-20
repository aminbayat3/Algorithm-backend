using algorithm.Models.Base;

namespace algorithm.Models
{
    public class AvailableConnectionLoad : Leg
    {
        public double ConnectionLoad { get; set; }

        public AvailableConnectionLoad(int number, DateTime startTime, DateTime endTime) : base(number, startTime, endTime)
        {
            ConnectionLoad = 20.00;
        }
    }
}
