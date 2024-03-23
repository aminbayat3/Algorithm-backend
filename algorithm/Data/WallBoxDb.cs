using algorithm.Models;

namespace algorithm.Data
{
    public static class WallBoxDb
    {
        public static List<WallBox> WallBoxes { get; } = new List<WallBox>()
       {
           //new WallBox { Id = "WB1", AcLimit = 11, IsActive = true },
           new WallBox { Id = "WB2", AcLimit = 11, IsActive = true },   
           //new WallBox { Id = "WB3", AcLimit = 11, IsActive = true },    
           new WallBox { Id = "WB4", AcLimit = 11, IsActive = true },
       };
    }
}
