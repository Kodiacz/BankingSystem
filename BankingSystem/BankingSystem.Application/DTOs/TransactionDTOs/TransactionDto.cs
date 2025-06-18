namespace BankingSystem.API.DTOs.TransactionDTOs;

public class TransactionDto
{
	public string ExternalId { get; set; } = string.Empty;

	public DateTime CreateDate { get; set; }

	public AmountDto Amount { get; set; } = new();

	public int Status { get; set; }

	public PartyDto Debtor { get; set; } = new();

	public PartyDto Beneficiary { get; set; } = new();
}
