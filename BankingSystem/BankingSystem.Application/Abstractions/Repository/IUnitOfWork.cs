namespace BankingSystem.Application.Abstractions.Repository;

public interface IUnitOfWork : IDisposable
{
	public ITransactionRepository Transaction { get; }

	public Task SaveAsync();
}
