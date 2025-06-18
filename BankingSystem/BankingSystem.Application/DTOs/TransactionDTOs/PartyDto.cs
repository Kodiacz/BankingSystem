namespace BankingSystem.API.DTOs.TransactionDTOs;

public class PartyDto
{
	public string BankName { get; set; } = string.Empty;
	public string BIC { get; set; } = string.Empty;
	public string IBAN { get; set; } = string.Empty;
}
