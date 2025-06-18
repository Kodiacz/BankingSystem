namespace BankingSystem.Domain.Base;

/// <summary>
/// Serves as the base class for all entities within the domain. 
/// It includes a primary identifier, soft delete functionality, and audit information 
/// to track when and by whom the entity was created or updated.
/// </summary>
/// <typeparam name="TId">
/// The type of the entity's primary identifier (typically int or GUID).
/// </typeparam>
public abstract class BaseEntity<TId> : ISoftDelete
{
	/// <summary>
	/// The primary identifier for the entity.
	/// </summary>
	public TId Id { get; set; }

	/// <summary>
	/// Indicates whether the entity is considered soft deleted.
	/// Soft delete means it's inactive or removed without being physically deleted.
	/// </summary>
	public bool IsDeleted { get; set; } = false;

	/// <summary>
	/// The timestamp when the entity was initially created.
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The timestamp when the entity was last updated.
	/// </summary>
	public DateTime? UpdatedAt { get; set; }

	/// <summary>
	/// The identifier or name of the actor who originally created the entity.
	/// </summary>
	public string CreatedBy { get; set; }

	/// <summary>
	/// The identifier or name of the actor who last updated the entity.
	/// </summary>
	public string UpdatedBy { get; set; }
}
