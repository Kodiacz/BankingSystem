namespace BankingSystem.Domain.Entities;

using BankingSystem.Domain.Base;

public class Partner : BaseEntity<Guid>
{
	public Partner()
	{
		this.Merchants = new List<Merchant>();
	}

	public string Name { get; set; } = string.Empty;

	public IEnumerable<Merchant> Merchants { get; set; }
}
