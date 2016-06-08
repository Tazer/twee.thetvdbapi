namespace twee.thetvdbapi
{
    public abstract class DefaultTheTvDbSettings : ITheTvDbSettings
    {
        public string BaseAddress { get; set; } = "https://api.thetvdb.com";
        public string Version { get; set; }
    }


}