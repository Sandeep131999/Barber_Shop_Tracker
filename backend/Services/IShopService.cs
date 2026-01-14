using backend.DTO;

namespace backend.Services;

/// <summary>
/// SERVICE = business logic layer for shops.
/// Talks to repositories and returns DTOs to the API.
/// </summary>
public interface IShopService
{
    /// <summary>
    /// High-level operation: "give me all shops".
    /// </summary>
    Task<IReadOnlyList<ShopDto>> GetAllAsync();
}
