using BankingSystem.Application.Implementations.Services;

namespace BankingSystem.Infrastructure.EntityConfiguration;

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{
		builder
			.HasKey(au => au.Id);

		builder
			.Property(au => au.FirstName)
			.IsRequired()
			.HasMaxLength(NAME_MAX_LENGTH);

		builder
			.Property(au => au.LastName)
			.IsRequired()
			.HasMaxLength(NAME_MAX_LENGTH);

		builder
			.Property(au => au.UserName)
			.IsRequired()
			.HasMaxLength(NAME_MAX_LENGTH);

		builder
			.Property(au => au.Email)
			.IsRequired()
			.HasMaxLength(EMAIL_MAX_LENGTH);

		builder
			.Property(au => au.PhoneNumber)
			.IsRequired()
			.HasMaxLength(NAME_MAX_LENGTH);

		builder
			.Property(au => au.PasswordHash)
			.IsRequired();

		builder
			.Property(au => au.PasswordSalt)
			.IsRequired();

		builder
			.HasMany(au => au.UserRoles)
			.WithOne(ur => ur.User)
			.HasForeignKey(ur => ur.UserId);

		builder
			.HasData(CreateDefaultUsers());
	}

	private List<ApplicationUser> CreateDefaultUsers()
	{
		var adminPassword = "1234";

		AuthService.CreateHash(adminPassword, out byte[] adminPasswordHash, out byte[] adminPasswordSalt);

		var adminUser = new ApplicationUser()
		{
			Id = Guid.Parse("e12bde0e-828c-409b-8087-84450617dcd8"),
			CreatedAt = DateTime.UtcNow,
			FirstName = "Sys",
			LastName = "Admin",
			UserName = "SysAdmin",
			CreatedBy = "System",
			Email = "SysAdmin@gmail.com",
			PasswordHash = Convert.ToBase64String(adminPasswordHash),
			PasswordSalt = Convert.ToBase64String(adminPasswordSalt),
			IsDeleted = false,
			PhoneNumber = "1234567890",
		};

		var normalUserPassword = "1234";

		AuthService.CreateHash(normalUserPassword, out byte[] normalUserPasswordHash, out byte[] normalUserPasswordSalt);

		var normalUser = new ApplicationUser()
		{
			Id = Guid.Parse("270c2aff-3a9b-4cdd-8eaf-b77181cc7c9b"),
			CreatedAt = DateTime.UtcNow,
			FirstName = "Normal",
			LastName = "User",
			UserName = "NormalUser",
			CreatedBy = "System",
			Email = "NormalUser@gmail.com",
			PasswordHash = Convert.ToBase64String(normalUserPasswordHash),
			PasswordSalt = Convert.ToBase64String(normalUserPasswordSalt),
			IsDeleted = false,
			PhoneNumber = "0987654321"
		};

		return new() { adminUser, normalUser };
	}
}
