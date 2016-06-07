namespace twee.thetvdbapi.test
{
    public class TestTheTvDbSettings : DefaultTheTvDbSettings
    {
        public TestTheTvDbSettings(string apikey)
        {
            ApiKey = apikey;
        }
        public override string ApiKey { get; }
    }
}