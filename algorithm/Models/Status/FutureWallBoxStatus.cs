using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace algorithm.Models.Status
{
    public class FutureWallBoxStatus
    {
        public string? CarId { get; set; }
        public string WallBoxId { get; set; }
        public bool IsConnected { get; set; }
        public double? NeededEnergy { get; set; }

        public FutureWallBoxStatus(string wallboxId)
        {
            NeededEnergy = null;
            IsConnected = false;
            WallBoxId = wallboxId;
            CarId = null;
        }

        public override string ToString()
        {
            return $"CarId: {CarId}, WallBoxId: {WallBoxId}, IsConnected: {IsConnected}, NeededEnergy: {NeededEnergy}";
        }
    }
}
