namespace BankingSystem.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
	private readonly BankingSystemDbContext _dbContext;

	public UnitOfWork(
		BankingSystemDbContext dbContext,
		ITransactionRepository transaction)
	{
		_dbContext = dbContext;
		Transaction = transaction;
	}

	public ITransactionRepository Transaction { get; }

	public void Dispose()
	{
		_dbContext.Dispose();
	}

	public async Task SaveAsync()
	{
		await _dbContext.SaveChangesAsync();
	}
}
