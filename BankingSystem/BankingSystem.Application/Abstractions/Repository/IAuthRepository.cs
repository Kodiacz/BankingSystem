namespace BankingSystem.Application.Abstractions.Repository;

public interface IAuthRepository
{
	Task CreateUserAsync(ApplicationUser registerData);
	Task<ApplicationUser?> GetUserByEmail(string email);
}
