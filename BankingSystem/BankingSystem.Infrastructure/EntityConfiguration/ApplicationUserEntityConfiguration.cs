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
			.HasMany(au => au.Roles)
			.WithMany(ar => ar.Users);
	}
}
