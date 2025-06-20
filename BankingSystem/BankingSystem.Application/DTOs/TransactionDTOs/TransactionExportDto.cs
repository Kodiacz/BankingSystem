namespace BankingSystem.Application.DTOs.TransactionDTOs;

public class TransactionExportDto
{
	public string ExternalId { get; set; } = string.Empty;

	public DateTime CreateDate { get; set; }

	public AmountExportDto Amount { get; set; } = new();

	public int Status { get; set; }

	public PartyExportDto Debtor { get; set; } = new();

	public PartyExportDto Beneficiary { get; set; } = new();
}
