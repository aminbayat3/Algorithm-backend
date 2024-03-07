namespace algorithm.Models.DTO
{
    public class CarFormDTO 
    {
        public List<CarViewDTO> Cars { get; set; }
        public int IntervalDurationInMinutes { get; set; } = 15;
        public int NumberOfCars { get; set; }
    }
}
