namespace BankingSystem.Application.Abstractions.Services;

public interface IJwtProvider
{
	public JwtToken GenerateToken(UserInfoDto user);
}
