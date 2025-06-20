namespace BankingSystem.Application.DTOs.TransactionDTOs;

public class AmountExportDto
{
	public string Direction { get; set; } = string.Empty;
	public decimal Value { get; set; }
	public string Currency { get; set; } = string.Empty;
}
