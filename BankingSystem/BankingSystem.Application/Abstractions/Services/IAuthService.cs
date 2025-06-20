namespace BankingSystem.Application.Abstractions.Services;

public interface IAuthService
{
	Task<UserInfoDto> LoginUserAsync(LoginInputData email);
	Task RegisterUserAsync(RegisterInputData registerData);
}
