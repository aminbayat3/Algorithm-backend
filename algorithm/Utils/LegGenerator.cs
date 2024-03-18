using algorithm.Models;
using algorithm.Models.Base;

namespace algorithm.Utils
{
    public class LegGenerator 
    {
        // these two methods have similar implementation , so we can write them in one function later instead of two
        public static List<SocLeg> GenerateSocLegs(DateTime startTime, DateTime endTime, int legDuration, List<Car> cars)
        {
            var socLegs = new List<SocLeg>();

            int counter = 1;

            while (startTime < endTime)
            {
                DateTime start = startTime;
                DateTime end = startTime.AddMinutes(legDuration);
                socLegs.Add(new SocLeg(counter, start, end, cars));
                startTime = end;
                counter++;
            }

            return socLegs;
        }

        public static List<WallBoxLeg> GenerateWallBoxLegs(DateTime startTime, DateTime endTime, int legDuration, List<WallBox> wallboxes)
        {
            var wallboxLegs = new List<WallBoxLeg>();

            int counter = 1;

            while (startTime < endTime)
            {
                DateTime start = startTime;
                DateTime end = startTime.AddMinutes(legDuration);
                wallboxLegs.Add(new WallBoxLeg(counter, start, end, wallboxes));
                startTime = end;
                counter++;
            }

            return wallboxLegs;

        }
    }
}
