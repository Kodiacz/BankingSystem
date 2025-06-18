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
	}
}
