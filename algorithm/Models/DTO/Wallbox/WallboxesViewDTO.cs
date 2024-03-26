namespace algorithm.Models.DTO.Wallbox
{
    public class WallboxesViewDTO
    {
        public List<WallboxDTO> Wallboxes { get; set; } = new List<WallboxDTO>();


        public WallboxesViewDTO(List<WallBox> wallboxes) 
        {
            wallboxes.ForEach(wallbox =>
            {
                Wallboxes.Add(new WallboxDTO() { Id = wallbox.Id, Name = wallbox.Id, AcLimit = wallbox.AcLimit });
            });
        }
        
    }
}
