using System;

namespace algorithm.Services
{
    public class CarService 
    {
        public dynamic  CalculateCarsReadyTime(List<double> sortedEnergyRequired, double connectedLoad, int numberOfCars, double hoursToFullCharge, List<double> expectedReadyTimes, double maxChargeCapacity, int counter = 0)
        {
            if (counter == (sortedEnergyRequired.Count - 1))
            {
                return 0;
            }
            double currentHours = (sortedEnergyRequired[counter + 1] - sortedEnergyRequired[counter]) / Math.Min((connectedLoad / numberOfCars), maxChargeCapacity);
            hoursToFullCharge += currentHours;
            expectedReadyTimes.Add(hoursToFullCharge);
            hoursToFullCharge = (sortedEnergyRequired[counter + 1] - sortedEnergyRequired[counter]) / Math.Min((connectedLoad / numberOfCars), maxChargeCapacity) + CalculateCarsReadyTime(sortedEnergyRequired, connectedLoad, numberOfCars - 1, hoursToFullCharge, expectedReadyTimes, maxChargeCapacity, counter + 1);

            return expectedReadyTimes;
        }
    }
}
