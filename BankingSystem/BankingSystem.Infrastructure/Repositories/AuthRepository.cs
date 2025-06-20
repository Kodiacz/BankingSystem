namespace BankingSystem.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
	private readonly BankingSystemDbContext dbContext;

	public AuthRepository(BankingSystemDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task CreateUserAsync(ApplicationUser registerData)
	{
		await this.dbContext.AddAsync(registerData);
	}

	public async Task<ApplicationUser?> GetUserByEmail(string email)
	{
		var user = await this.dbContext
			.ApplicationUsers
			.Include(u => u.UserRoles)
			.ThenInclude(u => u.Role)
			.FirstOrDefaultAsync(u => u.Email == email);

		return user;
	}
}
