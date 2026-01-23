using backend.Models;

namespace backend.Repository;
/// <summary>
/// REPOSITORY = talks directly to the database.
/// Handles Visitors persistence.
/// </summary>
public interface IVisitorRepository
{
    /// <summary>
    /// Inserts a customer.
    /// </summary>
    Task<Guid> InsertAsync(Visitor visits);

}
