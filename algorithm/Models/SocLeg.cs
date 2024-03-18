using algorithm.Models.Base;

namespace algorithm.Models
{
    public class SocLeg: Leg
    {
        public List<Car> Cars {  get; set; }
        public string? CarId { get; set; }
        public double Soc { get; set; }

        public SocLeg(int number, DateTime startTime, DateTime endTime, List<Car> cars): base(number, startTime, endTime)
        {
            Soc = 0;
            CarId = null;
            Cars = cars;

        }
    }
}
 