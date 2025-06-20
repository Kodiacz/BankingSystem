namespace BankingSystem.Infrastructure.EntityConfiguration;

public class ApplicationRoleEntityConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
	public void Configure(EntityTypeBuilder<ApplicationRole> builder)
	{
		builder
			.HasKey(ar => ar.Id);

		builder
			.Property(ar => ar.Name)
			.HasConversion<string>()
			.HasMaxLength(ROLE_NAME_MAX_LENGTH)
			.HasColumnType($"varchar({ROLE_NAME_MAX_LENGTH})");

		builder
		.Property(ar => ar.Description)
			.IsRequired()
			.HasMaxLength(ROLE_DESCRIPTION_MAX_LENGTH);

		builder
			.HasIndex(ar => ar.Name)
			.IsUnique();

		builder
			.HasMany(ar => ar.UserRoles)
			.WithOne(ur => ur.Role)
			.HasForeignKey(ur => ur.RoleId);

		builder
			.HasData(CreateDefaultRoles());
	}

	private List<ApplicationRole> CreateDefaultRoles()
	{
		return new List<ApplicationRole>
		{
			new ()
			{
				Id = Guid.Parse("a03cb524-1815-4b14-8ea3-e6a3dd206c48"),
				Name = ApplicationRoleNames.NormalUser,
				Description = "Default user role with basic permissions."
			},
			new ()
			{
				Id = Guid.Parse("6fd4d239-a763-4ee9-a125-2d5348a0665a"),
				Name = ApplicationRoleNames.Admin,
				Description = "Administrator role with full permissions."
			},
		};
	}
}
