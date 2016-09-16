using Microsoft.Extensions.Logging;

namespace twee.thetvdbapi
{
    public class TheTvDbClient
    {
        public TheTvDbClient(ILogger logger)
        {
            Authentication = new AuthenticationClient(logger);
            Series = new SeriesClient();
            Search = new SearchClient();
        }

        public AuthenticationClient Authentication { get; set; }
        public SeriesClient Series { get; set; }
        public SearchClient Search { get; set; }

    }
}