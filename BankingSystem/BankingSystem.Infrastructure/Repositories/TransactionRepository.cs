using BankingSystem.Application.Abstractions.Repository;

namespace BankingSystem.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
	private readonly BankingSystemDbContext _context;

	public TransactionRepository(BankingSystemDbContext context)
	{
		_context = context;
	}

	public async Task AddRangeAsync(List<Transaction> transactions)
	{
		await this._context.Transactions.AddRangeAsync(transactions);
	}
}
