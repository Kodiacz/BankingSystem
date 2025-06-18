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

		builder
			.HasData(CreateDefaultPartner());
	}

	private Partner CreateDefaultPartner()
	{
		return new Partner()
		{
			Id = Guid.Parse("bf9b7e93-aa9a-4686-b770-b6184245514e"),
			Name = "Acme Financial Group",
		};
	}
}
