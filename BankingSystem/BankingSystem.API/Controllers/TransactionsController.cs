using BankingSystem.Application.DTOs.CommonDTOs;

namespace BankingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TransactionsController : ControllerBase
{
	private readonly ITransactionService _transactionService;

	public TransactionsController(ITransactionService service)
	{
		this._transactionService = service;
	}

	[HttpPost]
	[Authorize(Roles = nameof(ApplicationRoleNames.Admin))]
	[ActionName(nameof(CreateTransaction))]
	public async Task<IActionResult> CreateTransaction([FromForm] CreateTransactionUploadRequest request)
	{
		if (request.File == null || request.File.Length == 0)
			return BadRequest(ControllersMessages.TRANSACTION_FAILED);

		using var stream = request.File.OpenReadStream();
		var operationDto = _transactionService.DeserializeXmlAsync(stream);
		var transactions = _transactionService.MapToTransactions(operationDto, request.MerchantId);
		await _transactionService.ImportTransactionsAsync(transactions);

		return Ok(ControllersMessages.TRANSACTION_SUCCESSFUL);
	}

	[HttpGet]
	[ActionName(nameof(ExportTransactions))]
	[Authorize(Roles = $"{nameof(ApplicationRoleNames.Admin)}, {nameof(ApplicationRoleNames.NormalUser)}")]
	public async Task<IActionResult> ExportTransactions([FromQuery] TransactionFilterDto filter)
	{
		var transactions = await _transactionService.GetFilteredTransactionsAsync(filter);
		var csv = await _transactionService.ExportTransactionsToCsvAsync(transactions);
		return File(csv, "text/csv", Helper.GetSafeTimestampedFileName(nameof(transactions), "csv"));
	}

	[HttpGet]
	[ActionName(nameof(GetPagedTransactions))]
	//[Authorize(Roles = $"{nameof(ApplicationRoleNames.Admin)}, {nameof(ApplicationRoleNames.NormalUser)}")]
	public async Task<ActionResult<PageResult<TransactionDto>>> GetPagedTransactions([FromQuery] TransactionQueryParameters parameters)
	{
		var result = await _transactionService.GetPagedTransactionsAsync(parameters);
		return Ok(result);
	}

}
