namespace twee.thetvdbapi
{
    public class DefaultTheTvDbSettings : ITheTvDbSettings
    {
        public string BaseAddress { get; set; } = "https://api.thetvdb.com";
        public string ApiKey { get; set; } 
        public string Version { get; set; }
    }
}