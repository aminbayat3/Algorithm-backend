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
            return $"CId: {CarId}, WBId: {WallBoxId}, IsCon?: {IsConnected}, Need: {NeededEnergy}";
        }

        public string CommandWB()
        {
            return $"WBId: {WallBoxId},  CL: {CurrentChargeLoad}";
        }
    }
}
