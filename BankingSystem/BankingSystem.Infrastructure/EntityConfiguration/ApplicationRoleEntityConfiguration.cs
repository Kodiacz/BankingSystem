namespace BankingSystem.Infrastructure.EntityConfiguration;

public class ApplicationRoleEntityConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
	public void Configure(EntityTypeBuilder<ApplicationRole> builder)
	{
		builder
			.HasKey(x => x.Id);

		builder
			.Property(ar => ar.Name)
			.IsRequired()
			.HasMaxLength(ROLE_NAME_MAX_LENGTH);
	}
}
