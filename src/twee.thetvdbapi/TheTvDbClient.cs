namespace twee.thetvdbapi
{
    public class TheTvDbClient
    {
        public TheTvDbClient()
        {
            Authentication = new AuthenticationClient();
            Series = new SeriesClient();
            Search = new SearchClient();
        }

        public AuthenticationClient Authentication { get; set; }
        public SeriesClient Series { get; set; }
        public SearchClient Search { get; set; }

    }
}