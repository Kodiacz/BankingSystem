namespace BankingSystem.Domain.Entities;

public class Merchant : BaseEntity<Guid>
{
	public Merchant()
	{
		this.Transactions = new List<Transaction>();
	}

	public string Name { get; set; } = string.Empty;

	public DateTime BoardingDate { get; set; }

	public string URL { get; set; } = string.Empty;

	public string Country { get; set; } = string.Empty;

	public Guid MainAddressId { get; set; }
	public Address MainAddress { get; set; } = null!;

	public Guid? SecondAddressId { get; set; }
	public Address? SecondAddress { get; set; } = null!;

	public Guid PartnerId { get; set; }
	public Partner Partner { get; set; }

	public List<Transaction> Transactions { get; set; }
}
