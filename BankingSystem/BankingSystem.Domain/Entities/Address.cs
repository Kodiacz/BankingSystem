﻿namespace BankingSystem.Domain.Entities;

public class Address : BaseEntity<Guid>
{
	public string Street { get; set; } = string.Empty;

	public string Number { get; set; } = string.Empty;

	public string PostalCode { get; set; } = string.Empty;

	public string City { get; set; } = string.Empty;

	public string Country { get; set; } = string.Empty;

	public Guid MerchantId { get; set; }
	public Merchant Merchant { get; set; }
}
