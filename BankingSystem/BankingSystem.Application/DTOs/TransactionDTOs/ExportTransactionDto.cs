namespace BankingSystem.Application.DTOs.TransactionDTOs;

public class ExportTransactionDto
{
	public string ExternalId { get; set; } = string.Empty;
	public DateTime CreateDate { get; set; }
	public string Direction { get; set; } = string.Empty;
	public decimal Amount { get; set; }
	public string Currency { get; set; } = string.Empty;
	public string DebtorIBAN { get; set; } = string.Empty;
	public string BeneficiaryIBAN { get; set; } = string.Empty;
	public string Status { get; set; } = string.Empty;
}
