using algorithm.Models.Base;

namespace algorithm.Models
{
    public class WallBoxLeg: Leg
    {
        public List<WallBox> WallBoxes { get; set; }
        public string? CarId { get; set; }
        public string? WallBoxId { get; set;}
        public bool IsConnected { get; set; }
        public double CurrentChargeLoad { get; set; }
        public double? NeedEnergy { get; set; }
        public double? FullEnergy { get; set; }

        public WallBoxLeg(int number, DateTime startTime, DateTime endtime, List<WallBox> wallBoxes): base(number, startTime, endtime)
        {
            WallBoxes = wallBoxes;
            CurrentChargeLoad = 20;
            IsConnected = false;
            WallBoxId = null;
            CarId =  null;
            NeedEnergy = null;
            FullEnergy = null;
        }
    }
}
