namespace twee.thetvdbapi.Models
{
    public class SerieResponse : BaseResponse
    {
        public SerieData Data { get; set; }
        public Errors Errors { get; set; }
    }
}