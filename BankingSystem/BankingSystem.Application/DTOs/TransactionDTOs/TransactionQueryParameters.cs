namespace BankingSystem.Application.DTOs.TransactionDTOs;

using static BankingSystem.Application.Constants.TransactionQueryParametersConstants;
using static BankingSystem.Application.Constants.Messages.ErrorMessages.Pagination;

public class TransactionQueryParameters
	: IPagedFilterableQuery<TransactionSortBy, TransactionGroupBy>
{
	public string? SearchTerm { get; set; }
	[DefaultValue(DEFAULT_PAGE_NUMBER)]
	[Range(DEFAULT_PAGE_NUMBER, int.MaxValue, ErrorMessage = PAGE_NUMBER_OUT_OF_RANGE)]
	public int PageNumber { get; set; } = 1;
	[DefaultValue(DEFAULT_PAGE_SIZE)]
	[Range(DEFAULT_PAGE_SIZE, int.MaxValue, ErrorMessage = PAGE_SIZE_OUT_OF_RANGE)]
	public int PageSize { get; set; } = 5;
	public TransactionSortBy? SortBy { get; set; }
	public SortOrder SortOrder { get; set; }
	public TransactionGroupBy? GroupBy { get; set; }
}
