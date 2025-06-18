using BankingSystem.Infrastructure.EntityConfiguration;

namespace BankingSystem.Infrastructure;

public class BankingSystemDbContext : DbContext
{
	public BankingSystemDbContext(DbContextOptions<BankingSystemDbContext> options) : base(options) { }

	public DbSet<ApplicationUser> ApplicationUsers { get; set; }

	public DbSet<ApplicationRole> ApplicationRoles { get; set; }

	public DbSet<Address> Addresses { get; set; }

	public DbSet<Partner> Partners { get; set; }

	public DbSet<Merchant> Merchants { get; set; }

	public DbSet<Transaction> Transactions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
		modelBuilder.ApplyConfiguration(new ApplicationRoleEntityConfiguration());
		modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
		modelBuilder.ApplyConfiguration(new MerchantEntityConfiguration());
		modelBuilder.ApplyConfiguration(new PartnerEntityConfiguration());
		modelBuilder.ApplyConfiguration(new TransactionEntityConfiguration());

		base.OnModelCreating(modelBuilder);
	}
}
