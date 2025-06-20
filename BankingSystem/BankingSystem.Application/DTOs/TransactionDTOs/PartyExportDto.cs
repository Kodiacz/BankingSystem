namespace BankingSystem.Application.DTOs.TransactionDTOs;

public class PartyExportDto
{
	public string BankName { get; set; } = string.Empty;
	public string BIC { get; set; } = string.Empty;
	public string IBAN { get; set; } = string.Empty;
}
