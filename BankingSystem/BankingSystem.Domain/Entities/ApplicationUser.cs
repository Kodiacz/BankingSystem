namespace BankingSystem.Domain.Entities;

public class ApplicationUser : BaseEntity<Guid>
{
	public ApplicationUser()
	{
		this.UserRoles = new List<ApplicationUserRole>();
	}

	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string UserName { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string PhoneNumber { get; set; } = string.Empty;

	public string PasswordHash { get; set; } = string.Empty;

	public string PasswordSalt { get; set; } = string.Empty;

	public List<ApplicationUserRole> UserRoles { get; set; }
}