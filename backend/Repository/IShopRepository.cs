using backend.Models;

namespace backend.Repository;

/// <summary>
/// REPOSITORY = talks directly to the database.
/// Hides Npgsql + SQL details from the rest of the app.
/// </summary>
public interface IShopRepository
{
    /// <summary>
    /// Returns all shops from PostgreSQL.
    /// </summary>
    Task<IReadOnlyList<Shops>> GetAllAsync();
}

