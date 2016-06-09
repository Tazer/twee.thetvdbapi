namespace twee.thetvdbapi.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int SortOrder { get; set; }
        public string Image { get; set; }
        public int? ImageAuthor { get; set; }
        public string ImageAdded { get; set; }
        public string LastUpdated { get; set; }
    }
}