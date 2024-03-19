using algorithm.Models;
using algorithm.Models.Base;
using algorithm.Models.Status;

namespace algorithm.Utils
{
    public class LegGenerator 
    {
        // these two methods have similar implementation , so we can write them in one function later instead of two
        public static Statuses GenerateLegs(DateTime startTime, DateTime endTime, int legDuration)
        {
            var socLegs = new List<StatusOfSocInCars>();
            var wallboxLegs = new List<StatusOnWallBoxes>();
            var simulatePiAndPo = new List<FutureStatusOnWallBoxes>();
            var connectionLoadLegs = new List<AvailableConnectionLoad>();

            int counter = 1;

            while (startTime < endTime)
            {
                DateTime start = startTime;
                DateTime end = startTime.AddMinutes(legDuration);
                socLegs.Add(new StatusOfSocInCars(counter, start, end));
                wallboxLegs.Add(new StatusOnWallBoxes(counter, start, end));
                connectionLoadLegs.Add(new AvailableConnectionLoad(counter, start, end));
                simulatePiAndPo.Add(new FutureStatusOnWallBoxes(counter, start, end));
                startTime = end;
                counter++;
            }

            return new Statuses(socLegs, wallboxLegs, connectionLoadLegs, simulatePiAndPo);
        }
    }
}
