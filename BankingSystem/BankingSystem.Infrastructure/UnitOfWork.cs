namespace BankingSystem.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
	private readonly BankingSystemDbContext _dbContext;

	public UnitOfWork(
		BankingSystemDbContext dbContext,
		ITransactionRepository transaction,
		IAuthRepository auth)
	{
		_dbContext = dbContext;
		Transaction = transaction;
		Auth = auth;
	}

	public ITransactionRepository Transaction { get; }
	public IAuthRepository Auth { get; }

	public void Dispose()
	{
		_dbContext.Dispose();
	}

	public async Task SaveAsync()
	{
		await _dbContext.SaveChangesAsync();
	}
}
