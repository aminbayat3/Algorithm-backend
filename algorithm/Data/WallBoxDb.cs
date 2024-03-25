using algorithm.Models;

namespace algorithm.Data
{
    public static class WallBoxDb
    {
        public static List<WallBox> WallBoxes { get; } = new List<WallBox>()
       {
           //new WallBox { Id = "WB1", Name="WB 1" AcLimit = 11, IsActive = true },
           new WallBox { Id = "WB2", Name="WB 2", AcLimit = 11, IsActive = true },   
           //new WallBox { Id = "WB3", Name="WB 3", AcLimit = 11, IsActive = true },    
           new WallBox { Id = "WB4", Name="WB 4", AcLimit = 11, IsActive = true },
       };

        public static void AddWallboxes(List<WallBox> wallboxes)
        {
            wallboxes.ForEach((wallbox) =>
            {
               WallBoxes.Add(wallbox);
            });
        }
    }
}
