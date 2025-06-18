namespace BankingSystem.Domain.Entities;

public class Transaction : BaseEntity<Guid>
{
	public TransactionDirection Direction { get; set; }

	public decimal Amount { get; set; }

	public string Currency { get; set; } = string.Empty;

	public string SourceIBAN { get; set; } = string.Empty;

	public string TargetIBAN { get; set; } = string.Empty;

	public TransactionStatus Status { get; set; }

	public string ExternalID { get; set; } = string.Empty;

	public Guid MerchantId { get; set; }
	public Merchant Merchant { get; set; }
}
