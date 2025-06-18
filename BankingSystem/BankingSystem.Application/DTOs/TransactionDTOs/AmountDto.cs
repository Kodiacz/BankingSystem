namespace BankingSystem.API.DTOs.TransactionDTOs;

public class AmountDto
{
	public string Direction { get; set; } = string.Empty; // "D" or "C"
	public decimal Value { get; set; }
	public string Currency { get; set; } = string.Empty;
}
