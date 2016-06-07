namespace twee.thetvdbapi
{
    public abstract class DefaultTheTvDbSettings : ITheTvDbSettings
    {
        public string BaseAddress { get; set; } = "https://api.thetvdb.com";
        public abstract string ApiKey { get; }
        public string Version { get; set; }
    }


}