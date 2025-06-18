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

		builder
			.HasData(CreateDefaultAddress());
	}

	private Address CreateDefaultAddress()
	{
		return new()
		{
			Id = Guid.Parse("ef149a3e-2c0f-45ef-b358-908fa8aa431e"),
			Street = "Main St.",
			Number = "123",
			City = "Sofia",
			PostalCode = "1000",
			Country = "Bulgaria",
		};
	}
}
