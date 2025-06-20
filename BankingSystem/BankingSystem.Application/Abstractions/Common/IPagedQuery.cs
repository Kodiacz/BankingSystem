namespace BankingSystem.Application.Abstractions.Common;

public interface IPagedQuery<TSortBy, TGroupBy>
	where TSortBy : struct, Enum
	where TGroupBy : struct, Enum
{
	int PageNumber { get; set; }
	int PageSize { get; set; }
	TSortBy? SortBy { get; set; }
	SortOrder SortOrder { get; set; }
	TGroupBy? GroupBy { get; set; }
}
