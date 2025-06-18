namespace BankingSystem.Infrastructure.EntityConfiguration;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<Transaction>
{
	public void Configure(EntityTypeBuilder<Transaction> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(t => t.Direction)
			.HasConversion<string>()
			.HasMaxLength(DIRECTION_MAX_LENGTH)
			.HasColumnType($"varchar({DIRECTION_MAX_LENGTH})");

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

		builder.Property(t => t.Status)
			.HasConversion<string>()
			.HasMaxLength(STATUS_MAX_LENGTH)
			.HasColumnType($"varchar({STATUS_MAX_LENGTH})");

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
