﻿namespace algorithm.Models.Base
{
    public class Event
    {
        public DateTime? Time { get; set; }
        public string CarId { get; set; }
        public string WallBoxId { get; set; }
        public bool IsPlugIn { get; set; }
    }
}
