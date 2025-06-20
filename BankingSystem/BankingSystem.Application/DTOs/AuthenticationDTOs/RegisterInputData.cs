namespace BankingSystem.Application.DTOs.AuthenticationDTOs;

public class RegisterInputData : LoginInputData
{
	[Required]
	public string ConfirmPassword { get; set; } = null!;

	[Required]
	public string FirstName { get; set; } = null!;

	[Required]
	public string LastName { get; set; } = null!;

	[Required]
	public string UserName { get; set; } = null!;

	[Required]
	public string PhoneNumber { get; set; } = string.Empty;
}
