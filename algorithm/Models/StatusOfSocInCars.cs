using algorithm.Data;
using algorithm.Models.Base;
using algorithm.Models.Status;

namespace algorithm.Models
{
    public class StatusOfSocInCars : Leg
    {
        public List<SocStatus> SocStatuses { get; set; }
        public StatusOfSocInCars(int number, DateTime startTime, DateTime endTime) : base(number, startTime, endTime)
        {
            SocStatuses = new List<SocStatus>();

            foreach (var car in CarDb.Cars)
            {
                SocStatuses.Add(new SocStatus(car.Id));
            }
        }

        public override string ToString()
        {
            string result = "SocStat: ";
            foreach (SocStatus status in SocStatuses)
            {
                result += status.ToString() + "\n";
            }
            return result;
        }
    }
}
