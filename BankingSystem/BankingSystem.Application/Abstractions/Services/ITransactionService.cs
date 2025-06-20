using BankingSystem.Application.DTOs.CommonDTOs;

namespace BankingSystem.Application.Abstractions.Services;

public interface ITransactionService
{
	public OperationDto DeserializeXmlAsync(Stream xmlStream);
	public List<Transaction> MapToTransactions(OperationDto dto, Guid merchantId);
	public Task ImportTransactionsAsync(List<Transaction> transactions);
	Task<byte[]> ExportTransactionsToCsvAsync(List<ExportTransactionDto> exportTransactionDto);
	Task<List<ExportTransactionDto>> GetFilteredTransactionsAsync(TransactionFilterDto filter);
	Task<PageResult<TransactionDto>> GetPagedTransactionsAsync(TransactionQueryParameters parameters);
}
