namespace BankingSystem.Domain.Interfaces;

/// <summary>
/// Defines the contract for entities that support soft deletion.
/// Soft deletion marks an entity as deleted without physically removing it from the database.
/// </summary>
public interface ISoftDelete
{
	/// <summary>
	/// Gets or sets a value indicating whether the entity is soft deleted.
	/// When true, the entity is considered deleted but retained in storage.
	/// </summary>
	public bool IsDeleted { get; set; }
}
