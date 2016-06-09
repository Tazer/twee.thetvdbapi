using System.Collections.Generic;

namespace twee.thetvdbapi.Models
{
    public class ImageQueryViewModel
    {
        public IEnumerable<Image> Data { get; set; }
        public Errors Errors { get; set; }
    }
}