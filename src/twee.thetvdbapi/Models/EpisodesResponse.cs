using System.Collections.Generic;

namespace twee.thetvdbapi.Models
{
    public class EpisodesResponse
    {
        public Links Links { get; set; }
        public IEnumerable<Episode> Data { get; set; }
        public Errors Errors { get; set; }
    }
}