namespace BankingSystem.Application.Implementations.Services;

public class AuthService : BaseService, IAuthService
{
	public AuthService(IUnitOfWork repositories) : base(repositories) { }

	public async Task<UserInfoDto> LoginUserAsync(LoginInputData loginData)
	{
		var user = await this.Repositories.Auth.GetUserByEmail(loginData.Email);

		if (user == null)
			throw new ApplicationArgumenNullException($"User with email '{loginData}' was not found.");

		if (!VerifyPasswordHash(user, loginData))
			throw new WrongPasswordException("Invalid credentials.");

		var userDto = new UserInfoDto()
		{
			Id = user.Id,
			FirstName = user.FirstName,
			LastName = user.LastName,
			Email = user.Email,
			PhoneNumber = user.PhoneNumber,
			UserName = user.UserName,
			Roles = user.UserRoles.Select(ur => new GetUserRoleDto()
			{
				Name = ur.Role.Name.ToString(),
			}).ToList()
		};

		return userDto;
	}

	public async Task RegisterUserAsync(RegisterInputData registerData)
	{
		if (!VerifyPasswordConfirmation(registerData.Password, registerData.ConfirmPassword))
			throw new InvalidOperationException("Password and confirm password do not match");

		CreateHash(registerData.Password, out byte[] passwordHash, out byte[] passwardSalt);

		ApplicationUser user = new()
		{
			PasswordHash = Convert.ToBase64String(passwordHash),
			PasswordSalt = Convert.ToBase64String(passwardSalt),
			FirstName = registerData.FirstName,
			LastName = registerData.LastName,
			UserName = registerData.UserName,
			Email = registerData.Email,
			PhoneNumber = registerData.PhoneNumber,

		};

		await Repositories.Auth.CreateUserAsync(user);
		await Repositories.SaveAsync();
	}

	public static void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
	{
		using (var hmac = new HMACSHA512())
		{
			passwordSalt = hmac.Key;
			passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
		}
	}

	private bool VerifyPasswordHash(ApplicationUser user, LoginInputData dto)
	{
		var passwordSaltByte = Convert.FromBase64String(user.PasswordSalt);
		using (var hmac = new HMACSHA512(passwordSaltByte))
		{
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
			return computedHash.SequenceEqual(Convert.FromBase64String(user.PasswordHash));
		}
	}

	private bool VerifyPasswordConfirmation(string password, string confirmedPassword)
	{
		return password.Equals(confirmedPassword);
	}
}
