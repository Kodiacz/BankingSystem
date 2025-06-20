namespace BankingSystem.Application.DTOs.AuthenticationDTOs;

public class UserInfoDto
{
	public Guid Id { get; set; }

	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string UserName { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string PhoneNumber { get; set; } = string.Empty;

	public ICollection<GetUserRoleDto> Roles { get; set; } = null!;
}
