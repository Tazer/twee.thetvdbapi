using System.Collections.Generic;

namespace twee.thetvdbapi.Models
{
    public class ActorsResponse
    {
        public IEnumerable<Actor> Data { get; set; }
        public Errors Errors { get; set; }
    }
}