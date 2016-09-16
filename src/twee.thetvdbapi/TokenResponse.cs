namespace twee.thetvdbapi
{
    public class TokenResponse : BaseResponse
    {
        public int? Expire { get; set; }
        public string Token { get; set; }
    }
}