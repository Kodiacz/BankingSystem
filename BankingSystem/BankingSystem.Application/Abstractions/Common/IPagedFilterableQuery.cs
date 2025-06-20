namespace BankingSystem.Application.Abstractions.Common;

public interface IPagedFilterableQuery<TSortBy, TGroupBy> : IPagedQuery<TSortBy, TGroupBy>
	where TSortBy : struct, Enum
	where TGroupBy : struct, Enum
{
	string? SearchTerm { get; set; }
}
