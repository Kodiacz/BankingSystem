namespace BankingSystem.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
	private readonly BankingSystemDbContext _context;

	public TransactionRepository(BankingSystemDbContext context)
	{
		_context = context;
	}

	/// <summary>
	/// Adds a range of transactions to the database context asynchronously.
	/// </summary>
	/// <param name="transactions">The list of transactions to add.</param>
	public async Task AddRangeAsync(List<Transaction> transactions)
	{
		await this._context.Transactions.AddRangeAsync(transactions);
	}

	/// <summary>
	/// Retrieves a paged, filtered, and sorted list of transactions as read-only, including related merchant data.
	/// </summary>
	/// <param name="parameters">The query parameters for filtering, sorting, and pagination.</param>
	/// <returns>A list of transactions matching the specified parameters, or null if an exception occurs.</returns>
	public async Task<List<Transaction>> GetAllPagedTransactionsAsReadOnlyAsync(TransactionQueryParameters parameters)
	{
		IQueryable<Transaction> query = _context.Transactions.AsQueryable();

		query = query.ApplyTransactionsFilters(parameters);
		query = query.ApplyTransactionsSorting(parameters);

		return await query.AsNoTracking()
						  .Include(t => t.Merchant)
						  .ApplyTransactionPagination(parameters.PageNumber, parameters.PageSize)
						  .ToListAsync();
	}

	/// <summary>
	/// Retrieves a list of transactions from the provided query as read-only (no tracking).
	/// </summary>
	/// <param name="query">The transaction query to execute.</param>
	/// <returns>A list of transactions from the query.</returns>
	public async Task<List<Transaction>> GetTransactionsAsReadOnlyAsync(IQueryable<Transaction> query)
	{
		return await query.AsNoTracking()
						  .Include(t => t.Merchant)
						  .ToListAsync();
	}

	/// <summary>
	/// Builds a queryable collection of transactions filtered by the specified filter DTO.
	/// </summary>
	/// <param name="filter">The filter DTO containing filter criteria.</param>
	/// <returns>An <see cref="IQueryable{Transaction}"/> with the applied filters.</returns>
	public IQueryable<Transaction> GetTransactionsQuery(TransactionFilterDto filter)
	{
		var query = _context.Transactions.AsQueryable();

		if (filter.FromDate.HasValue)
			query = query.Where(t => t.CreatedAt >= filter.FromDate.Value);

		if (filter.ToDate.HasValue)
			query = query.Where(t => t.CreatedAt <= filter.ToDate.Value);

		if (filter.Direction.HasValue)
			query = query.Where(t => t.Direction == filter.Direction);

		if (!string.IsNullOrEmpty(filter.Currency))
			query = query.Where(t => t.Currency == filter.Currency);

		if (filter.Status.HasValue)
			query = query.Where(t => t.Status == filter.Status);

		return query;
	}
}
