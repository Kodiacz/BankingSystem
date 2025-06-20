namespace BankingSystem.Application.DTOs.CommonDTOs;

public class PageResult<TItems>
{
	public PageResult()
	{
		this.Items = new List<TItems>();
	}

	public IEnumerable<TItems> Items { get; set; }
	public int TotalCount { get; set; }
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
}

