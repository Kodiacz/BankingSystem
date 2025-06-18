namespace BankingSystem.API.DTOs.TransactionDTOs;

public class CreateTransactionUploadRequest
{
	public IFormFile File { get; set; } = null!;
	public Guid MerchantId { get; set; } = Guid.Empty;
}
