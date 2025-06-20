namespace BankingSystem.Application.DTOs.TransactionDTOs;

public class TransactionDto
{
	public TransactionDirection Direction { get; set; }
	public DateTime CreateDate { get; set; }

	public decimal Amount { get; set; }

	public string Currency { get; set; } = string.Empty;

	public string SourceIBAN { get; set; } = string.Empty;

	public string TargetIBAN { get; set; } = string.Empty;

	public TransactionStatus Status { get; set; }

	public string ExternalID { get; set; } = string.Empty;

	public Merchant Merchant { get; set; }
}
