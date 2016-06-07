namespace twee.thetvdbapi
{
    public interface ITheTvDbSettings
    {
        string BaseAddress{ get; set; }
        string ApiKey{ get; set; }
        string Version{ get; set; }
        
    }
}