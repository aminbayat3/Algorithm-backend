namespace algorithm.Models.Status
{
    public class WallBoxStatus
    {
        public string? CarId { get; set; }
        public string? WallBoxId { get; set; }
        public bool IsConnected { get; set; }
        public double CurrentChargeLoad { get; set; }

        public WallBoxStatus()
        {
            CurrentChargeLoad = 0;
            IsConnected = false;
            WallBoxId = null;
            CarId = null;
        }
    }
}
