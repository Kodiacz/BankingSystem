namespace BankingSystem.Application.Abstractions.Services;

public interface ITransactionService
{
	public OperationDto DeserializeXmlAsync(Stream xmlStream);
	public List<Transaction> MapToTransactions(OperationDto dto, Guid merchantId);
	public Task ImportTransactionsAsync(List<Transaction> transactions);
}
