namespace BankingSystem.Infrastructure.EntityConfiguration;

public class MerchantEntityConfiguration : IEntityTypeConfiguration<Merchant>
{
	public void Configure(EntityTypeBuilder<Merchant> builder)
	{
		builder.HasKey(m => m.Id);

		builder.Property(m => m.Name)
			   .IsRequired()
			   .HasMaxLength(100);

		builder.Property(m => m.URL);

		builder.Property(m => m.Country)
			   .IsRequired()
			   .HasMaxLength(COUNTRY_MAX_LENGTH);

		builder.Property(m => m.BoardingDate)
			   .IsRequired();

		builder.HasOne(m => m.MainAddress)
			   .WithOne()
			   .HasForeignKey<Merchant>(m => m.MainAddressId)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(m => m.SecondAddress)
			   .WithOne()
			   .HasForeignKey<Merchant>(m => m.SecondAddressId)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(m => m.Transactions)
			   .WithOne()
			   .HasForeignKey(x => x.MerchantId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder
			.HasData(CreaterDefaultMerchant());
	}

	private Merchant CreaterDefaultMerchant()
	{
		return new()
		{
			Id = Guid.Parse("1c751a11-50a3-4574-b65d-ca3272b13fd5"),
			Name = "Acme Online Store",
			BoardingDate = DateTime.UtcNow,
			URL = "https://acmestore.com",
			Country = "Bulgaria",
			MainAddressId = Guid.Parse("ef149a3e-2c0f-45ef-b358-908fa8aa431e"),
			PartnerId = Guid.Parse("bf9b7e93-aa9a-4686-b770-b6184245514e"),
		};

	}
}
