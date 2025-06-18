namespace BankingSystem.Infrastructure.EntityConfiguration;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<Transaction>
{
	public void Configure(EntityTypeBuilder<Transaction> builder)
	{
		builder.HasKey(t => t.Id);

		builder
			.Property(t => t.Direction)
			.IsRequired();

		builder
			.Property(t => t.Amount)
			.IsRequired()
			.HasColumnType("decimal(18,2)");

		builder
			.Property(t => t.Currency)
			.IsRequired()
			.HasMaxLength(CURRENCY_MAX_LENGTH);

		builder
			.Property(t => t.SourceIBAN)
			.IsRequired()
			.HasMaxLength(IBAN_MAX_LENGTH);

		builder
			.Property(t => t.TargetIBAN)
			.IsRequired()
			.HasMaxLength(IBAN_MAX_LENGTH);

		builder
			.Property(t => t.Status)
			.IsRequired();

		builder
			.Property(t => t.ExternalID)
			.IsRequired();

		builder
			.HasOne(t => t.Merchant)
			.WithMany(m => m.Transactions)
			.HasForeignKey(t => t.MerchantId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
