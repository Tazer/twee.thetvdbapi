namespace twee.thetvdbapi
{
    public class TheTvDbClient
    {
        public TheTvDbClient()
        {
            Authentication = new AuthenticationClient();
            Series = new SeriesClient();
        }

        public AuthenticationClient Authentication { get; set; }
        public SeriesClient Series { get; set; }

    }
}