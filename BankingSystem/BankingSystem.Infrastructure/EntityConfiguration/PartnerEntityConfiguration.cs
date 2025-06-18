namespace BankingSystem.Infrastructure.EntityConfiguration;

public class PartnerEntityConfiguration : IEntityTypeConfiguration<Partner>
{
	public void Configure(EntityTypeBuilder<Partner> builder)
	{
		builder.HasKey(p => p.Id);

		builder
			.Property(p => p.Name)
			.IsRequired()
			.HasMaxLength(NAME_MAX_LENGTH);

		builder
			.HasMany(p => p.Merchants)
			.WithOne(m => m.Partner)
			.HasForeignKey(m => m.PartnerId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
