namespace algorithm.Utils
{
    public class ConnectedCarStatus
    {
        public string CarId { get; set; }
        public double Tanksize { get; set; }
        public double NeededEnergy { get; set; }
        public DateTime Expo {  get; set; }

        public ConnectedCarStatus(string carId, double tanksize, double neededEnergy, DateTime expo) 
        {
            CarId = carId;
            Tanksize = tanksize;
            NeededEnergy = neededEnergy;
            Expo = expo;
        }
    }
}
