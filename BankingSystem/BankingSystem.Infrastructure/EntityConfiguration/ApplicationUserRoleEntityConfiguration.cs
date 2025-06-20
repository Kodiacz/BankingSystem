
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.EntityConfiguration;

public class ApplicationUserRoleEntityConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
{
	public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
	{
		builder
	   .HasKey(ur => new { ur.UserId, ur.RoleId });

		builder
			.HasOne(ur => ur.User)
			.WithMany(u => u.UserRoles)
			.HasForeignKey(ur => ur.UserId);

		builder
			.HasOne(ur => ur.Role)
			.WithMany(r => r.UserRoles)
			.HasForeignKey(ur => ur.RoleId);

		builder
			.HasData(CreateDefaultApplicationUserRole());
	}

	private List<ApplicationUserRole> CreateDefaultApplicationUserRole()
	{
		return new()
		{
			new()
			{
				UserId = Guid.Parse("e12bde0e-828c-409b-8087-84450617dcd8"),
				RoleId = Guid.Parse("6fd4d239-a763-4ee9-a125-2d5348a0665a")
			},
			new()
			{
				UserId = Guid.Parse("270c2aff-3a9b-4cdd-8eaf-b77181cc7c9b"),
				RoleId = Guid.Parse("a03cb524-1815-4b14-8ea3-e6a3dd206c48")
			}
		};
	}
}
