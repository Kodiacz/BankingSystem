namespace BankingSystem.Application.Extensions;

public static class TransactionQueryableExtensions
{
	/// <summary>
	/// Applies filtering to the transaction query based on the provided search term.
	/// Filters by SourceIBAN, TargetIBAN, Currency, and also supports partial matches for TransactionStatus and TransactionDirection enums.
	/// </summary>
	/// <param name="query">The transaction query to filter.</param>
	/// <param name="parameters">The query parameters containing the search term.</param>
	/// <returns>The filtered transaction query.</returns>
	public static IQueryable<Transaction> ApplyTransactionsFilters(this IQueryable<Transaction> query, TransactionQueryParameters parameters)
	{
		if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
		{
			var term = parameters.SearchTerm.Trim().ToLower();

			var matchedStatus = Enum.GetValues(typeof(TransactionStatus))
				.Cast<TransactionStatus?>()
				.FirstOrDefault(e => e.HasValue && e.Value.ToString().ToLower().Contains(term));

			var matchedDirection = Enum.GetValues(typeof(TransactionDirection))
				.Cast<TransactionDirection?>()
				.FirstOrDefault(e => e.HasValue && e.Value.ToString().ToLower().Contains(term));

			query = query.Where(t =>
				t.SourceIBAN.ToLower().Contains(term) ||
				t.TargetIBAN.ToLower().Contains(term) ||
				t.Currency.ToLower().Contains(term) ||
				(matchedStatus.HasValue && t.Status == matchedStatus.Value) ||
				(matchedDirection.HasValue && t.Direction == matchedDirection.Value)
			);
		}

		return query;
	}

	/// <summary>
	/// Applies sorting to the transaction query based on the specified sort by and sort order parameters.
	/// Defaults to sorting by Id if no sort parameter is provided.
	/// </summary>
	/// <param name="query">The transaction query to sort.</param>
	/// <param name="parameters">The query parameters containing sorting options.</param>
	/// <returns>The sorted transaction query.</returns>
	public static IQueryable<Transaction> ApplyTransactionsSorting(this IQueryable<Transaction> query, TransactionQueryParameters parameters)
	{
		if (parameters.SortBy is null)
			return query.OrderBy(t => t.Id);

		return (parameters.SortBy, parameters.SortOrder) switch
		{
			(TransactionSortBy.CreatedAt, SortOrder.Ascending) => query.OrderBy(t => t.CreatedAt),
			(TransactionSortBy.CreatedAt, SortOrder.Descending) => query.OrderByDescending(t => t.CreatedAt),

			(TransactionSortBy.Amount, SortOrder.Ascending) => query.OrderBy(t => t.Amount),
			(TransactionSortBy.Amount, SortOrder.Descending) => query.OrderByDescending(t => t.Amount),

			(TransactionSortBy.Currency, SortOrder.Ascending) => query.OrderBy(t => t.Currency),
			(TransactionSortBy.Currency, SortOrder.Descending) => query.OrderByDescending(t => t.Currency),

			(TransactionSortBy.Status, SortOrder.Ascending) => query.OrderBy(t => t.Status),
			(TransactionSortBy.Status, SortOrder.Descending) => query.OrderByDescending(t => t.Status),

			_ => query
		};
	}

	/// <summary>
	/// Groups the transaction query results by the specified group by parameter.
	/// If no group by parameter is provided, all transactions are grouped together.
	/// </summary>
	/// <param name="query">The transaction query to group.</param>
	/// <param name="groupBy">The group by option.</param>
	/// <returns>The grouped transaction query.</returns>
	public static IQueryable<IGrouping<object, Transaction>> ApplyTransactionsGrouping(this IQueryable<Transaction> query, TransactionGroupBy? groupBy)
	{
		if (groupBy is null)
			return query.GroupBy(_ => (object)1);

		return groupBy switch
		{
			TransactionGroupBy.Direction => query.GroupBy(t => (object)t.Direction),
			TransactionGroupBy.Currency => query.GroupBy(t => (object)t.Currency),
			TransactionGroupBy.Status => query.GroupBy(t => (object)t.Status),
			_ => query.GroupBy(_ => (object)1)
		};
	}

	/// <summary>
	/// Applies pagination to the query based on the specified page number and page size.
	/// </summary>
	/// <typeparam name="T">The type of the query elements.</typeparam>
	/// <param name="query">The query to paginate.</param>
	/// <param name="pageNumber">The page number (1-based).</param>
	/// <param name="pageSize">The number of items per page.</param>
	/// <returns>The paginated query.</returns>
	public static IQueryable<T> ApplyTransactionPagination<T>(this IQueryable<T> query, int pageNumber, int pageSize)
	{
		int skip = (pageNumber - 1) * pageSize;
		return query.Skip(skip).Take(pageSize);
	}
}
