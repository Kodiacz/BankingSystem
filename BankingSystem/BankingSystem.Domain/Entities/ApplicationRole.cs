namespace BankingSystem.Domain.Entities;

public class ApplicationRole : BaseEntity<Guid>
{
	public ApplicationRole()
	{
		this.UserRoles = new List<ApplicationUserRole>();
	}

	public ApplicationRoleNames Name { get; set; }

	public string Description { get; set; }

	public IEnumerable<ApplicationUserRole> UserRoles { get; set; }
}
