namespace ResumeProfile.Application.Dtos.AccountDtos;

public class TokenInfoDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime AccessTokenExpires { get; set; }
}

public class TokenInfo
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}