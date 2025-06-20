namespace BankingSystem.Application.DTOs.AuthenticationDTOs;

public class LoginInputData
{
	[Required]
	public string Email { get; set; } = null!;

	[Required]
	public string Password { get; set; } = null!;
}
