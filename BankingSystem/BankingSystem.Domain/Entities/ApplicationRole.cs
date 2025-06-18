namespace BankingSystem.Domain.Entities;

public class ApplicationRole : BaseEntity<Guid>
{
	public ApplicationRole()
	{
		this.Users = new List<ApplicationUser>();
	}

	public string Name { get; set; } = string.Empty;

	public IEnumerable<ApplicationUser> Users { get; set; }
}
