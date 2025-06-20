namespace BankingSystem.Application.Abstractions.Repository;

public interface ITransactionRepository
{
	Task AddRangeAsync(List<Transaction> transactions);
	public IQueryable<Transaction> GetTransactionsQuery(TransactionFilterDto filter);
	Task<List<Transaction>> GetTransactionsAsReadOnlyAsync(IQueryable<Transaction> query);
	Task<List<Transaction>> GetAllPagedTransactionsAsReadOnlyAsync(TransactionQueryParameters parameters);
}
