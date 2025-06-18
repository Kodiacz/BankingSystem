namespace BankingSystem.Application.Abstractions.Repository;

public interface ITransactionRepository
{
	Task AddRangeAsync(List<Transaction> transactions);
}
