namespace BankingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TransactionsController : ControllerBase
{
	private readonly ITransactionService service;

	public TransactionsController(ITransactionService service)
	{
		this.service = service;
	}

	[HttpPost]
	[ActionName(nameof(CreateTransaction))]
	public async Task<IActionResult> CreateTransaction([FromForm] CreateTransactionUploadRequest request)
	{
		if (request.File == null || request.File.Length == 0)
			return BadRequest("No file uploaded.");

		using var stream = request.File.OpenReadStream();
		var operationDto = service.DeserializeXmlAsync(stream);
		var transactions = service.MapToTransactions(operationDto, request.MerchantId);
		await service.ImportTransactionsAsync(transactions);

		return Ok("Transactions imported successfully.");
	}
}
