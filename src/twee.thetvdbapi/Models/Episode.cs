﻿using System;

namespace twee.thetvdbapi.Models
{
    public class Episode
    {
        public int? AbsoluteNumber { get; set; }
        public int? AiredEpisodeNumber { get; set; }
        public int? AiredSeason { get; set; }
        public string DvdEpisodeNumber { get; set; }
        public int? DvdSeason { get; set; }
        public string EpisodeName { get; set; }
        public int Id { get; set; }
        public string Overview { get; set; }
        public DateTime? FirstAired { get; set; }
    }
}