namespace BankingSystem.Application.DTOs.AuthenticationDTOs;

public class JwtToken
{

	public string AccessToken { get; set; } = null!;

	public UserInfoDto User { get; set; } = null!;
}
