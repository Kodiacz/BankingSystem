namespace BankingSystem.Application.Implementations.Services;

public class TransactionService : BaseService, ITransactionService
{
	public TransactionService(IUnitOfWork repositories) : base(repositories) { }

	public OperationDto DeserializeXmlAsync(Stream xmlStream)
	{
		var serializer = new XmlSerializer(typeof(OperationDto));
		return (OperationDto)serializer.Deserialize(xmlStream)!;
	}

	public async Task<byte[]> ExportTransactionsToCsvAsync(List<ExportTransactionDto> exportTransactionDto)
	{
		var sb = new StringBuilder();
		sb.AppendLine("ExternalId,CreateDate,Direction,Amount,Currency,DebtorIBAN,BeneficiaryIBAN,Status");

		foreach (var tx in exportTransactionDto)
		{
			sb.AppendLine($"{tx.ExternalId},{tx.CreateDate:O},{tx.Direction},{tx.Amount},{tx.Currency},{tx.DebtorIBAN},{tx.BeneficiaryIBAN},{tx.Status}");
		}

		return Encoding.UTF8.GetBytes(sb.ToString());
	}

	public async Task<List<ExportTransactionDto>> GetFilteredTransactionsAsync(TransactionFilterDto filter)
	{
		var query = Repositories.Transaction.GetTransactionsQuery(filter);
		var transactions = await Repositories.Transaction.GetTransactionsAsReadOnlyAsync(query);

		var exportingTransactionDto = transactions
		.Select(t => new ExportTransactionDto
		{
			ExternalId = t.ExternalID,
			CreateDate = t.CreatedAt,
			Direction = t.Direction.ToString(),
			Amount = t.Amount,
			Currency = t.Currency,
			DebtorIBAN = t.SourceIBAN,
			BeneficiaryIBAN = t.TargetIBAN,
			Status = t.Status.ToString()
		})
		.ToList();

		return exportingTransactionDto;
	}

	public async Task<PageResult<TransactionDto>> GetPagedTransactionsAsync(TransactionQueryParameters parameters)
	{
		var transactions = await Repositories.Transaction.GetAllPagedTransactionsAsReadOnlyAsync(parameters);
		var transactionsDtos = transactions.Select(t =>
			new TransactionDto
			{
				ExternalID = t.ExternalID,
				CreateDate = t.CreatedAt,
				Direction = t.Direction,
				Amount = t.Amount,
				Currency = t.Currency,
				SourceIBAN = t.SourceIBAN,
				TargetIBAN = t.TargetIBAN,
				Status = t.Status
			}).ToList();

		var totalCount = transactionsDtos.Count;

		return new PageResult<TransactionDto>
		{
			Items = transactionsDtos,
			PageNumber = parameters.PageNumber,
			PageSize = parameters.PageSize,
			TotalCount = totalCount
		};
	}

	public async Task ImportTransactionsAsync(List<Transaction> transactions)
	{
		await Repositories.Transaction.AddRangeAsync(transactions);
		await Repositories.SaveAsync();
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
