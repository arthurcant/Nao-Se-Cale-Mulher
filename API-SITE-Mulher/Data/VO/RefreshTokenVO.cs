namespace API_SITE_Mulher.Data.VO
{
    public class RefreshTokenVO
    {
        public RefreshTokenVO(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
