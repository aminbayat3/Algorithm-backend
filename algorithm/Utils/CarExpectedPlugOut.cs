namespace algorithm.Utils
{
    public class CarExpectedPlugOut
    {
        public DateTime Expo {  get; set; }
        public string CarId { get; set; }

        public CarExpectedPlugOut(DateTime expo, string carId)
        {
            Expo = expo;
            CarId = carId;
        }
    }
}
