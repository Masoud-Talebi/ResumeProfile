namespace ResumeProfile.Domain.Entities.IdentityEntities
{
    public class UserToken:IdentityUserToken<long>
    {
        public long Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpires { get; set; }
        public virtual User User { get; set; }
    }
}