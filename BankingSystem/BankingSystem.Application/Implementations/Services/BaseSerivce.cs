namespace BankingSystem.Application.Implementations.Services;

public class BaseService
{
	private readonly IUnitOfWork _repositories;

	public BaseService(IUnitOfWork repositories)
	{
		_repositories = repositories;
	}

	protected IUnitOfWork Repositories => _repositories;
}
