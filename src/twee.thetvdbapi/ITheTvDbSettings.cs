namespace twee.thetvdbapi
{
    public interface ITheTvDbSettings
    {
        string BaseAddress{ get; set; }
        string ApiKey{ get; }
        string Version{ get; set; }
        
    }
}