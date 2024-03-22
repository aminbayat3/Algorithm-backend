namespace algorithm.Models.Status
{
    public class WallBoxStatus
    {
        public string? CarId { get; set; }
        public string WallBoxId { get; set; }
        public bool IsConnected { get; set; }
        public double NeededEnergy { get; set; }
        public double CurrentChargeLoad { get; set; }

        public WallBoxStatus(string wallboxId)
        {
            CurrentChargeLoad = 0;
            IsConnected = false;
            NeededEnergy = 0;
            WallBoxId = wallboxId;
            CarId = null;
        }

        public override string ToString()
        {
            return $"CarId: {CarId}, WallBoxId: {WallBoxId}, IsConnected: {IsConnected}, NeededEnergy: {NeededEnergy}";
        }

        public string CommandWB()
        {
            return $"WallBoxId: {WallBoxId},  CurrentChargeLoad: {CurrentChargeLoad}";
        }
    }
}
