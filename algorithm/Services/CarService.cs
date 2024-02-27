using System;

namespace algorithm.Services
{
    public class CarService 
    {
        public List<double> CalculateCarsReadyTime(List<double> sortedEnergyRequired, double connectedLoad, int numberOfCars, double maxChargeCapacity)
        {
            double total = 0;
            var readyTimes = new List<double>();

            for(int i = 0; i < sortedEnergyRequired.Count - 1; i++)
            {
                total += (sortedEnergyRequired[i + 1] - sortedEnergyRequired[i]) / Math.Min((double)connectedLoad / numberOfCars, maxChargeCapacity);
                readyTimes.Add(total);
                
                // here we could instead use a counter, so we dont have to reduce number of cars
                numberOfCars--;
            }

            return readyTimes;
        }
    }
}
