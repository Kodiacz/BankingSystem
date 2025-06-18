namespace BankingSystem.Infrastructure.EntityConfiguration;

public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
	public void Configure(EntityTypeBuilder<Address> builder)
	{
		builder.HasKey(a => a.Id);

		builder.Property(a => a.Street)
			.IsRequired()
			.HasMaxLength(STREET_MAX_LENGTH);

		builder.Property(a => a.City)
			.IsRequired()
			.HasMaxLength(CITY_MAX_LENGTH);

		builder.Property(a => a.Number)
			.IsRequired()
			.HasMaxLength(STREET_NUMBER_MAX_LENGTH);

		builder.Property(a => a.PostalCode)
			.IsRequired()
			.HasMaxLength(POSTAL_CODE_MAX_LENGTH);

		builder.Property(a => a.Country)
			.IsRequired()
			.HasMaxLength(COUNTRY_MAX_LENGTH);
	}
}
