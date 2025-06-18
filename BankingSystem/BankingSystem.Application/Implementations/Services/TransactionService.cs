namespace BankingSystem.Application.Implementations.Services;

public class TransactionService : ITransactionService
{
	private readonly IUnitOfWork _repositories;

	public TransactionService(IUnitOfWork transactionRepository)
	{
		_repositories = transactionRepository;
	}

	public OperationDto DeserializeXmlAsync(Stream xmlStream)
	{
		var serializer = new XmlSerializer(typeof(OperationDto));
		return (OperationDto)serializer.Deserialize(xmlStream)!;
	}

	public async Task ImportTransactionsAsync(List<Transaction> transactions)
	{
		await _repositories.Transaction.AddRangeAsync(transactions);
		await _repositories.SaveAsync();
	}

	public List<Transaction> MapToTransactions(OperationDto dto, Guid merchantId)
	{
		return dto.Transactions.Select(t => new Transaction
		{
			ExternalID = t.ExternalId,
			CreatedAt = t.CreateDate,
			Amount = t.Amount.Value,
			Currency = t.Amount.Currency,
			Direction = t.Amount.Direction == "D" ? TransactionDirection.Debit : TransactionDirection.Credit,
			Status = t.Status == 1 ? TransactionStatus.Successful : TransactionStatus.Failed,
			SourceIBAN = t.Debtor.IBAN,
			TargetIBAN = t.Beneficiary.IBAN,
			MerchantId = merchantId
		}).ToList();
	}
}
