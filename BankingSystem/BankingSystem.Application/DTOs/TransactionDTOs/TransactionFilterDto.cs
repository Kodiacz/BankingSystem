namespace BankingSystem.Application.DTOs.TransactionDTOs;

public class TransactionFilterDto
{
	public DateTime? FromDate { get; set; }
	public DateTime? ToDate { get; set; }
	public TransactionDirection? Direction { get; set; }
	public string? Currency { get; set; }
	public TransactionStatus? Status { get; set; }
}
