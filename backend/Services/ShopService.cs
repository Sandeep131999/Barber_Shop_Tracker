using backend.DTO;
using backend.Models;
using backend.Repository;

namespace backend.Services;

/// <summary>
/// SERVICE implementation for shops.
/// </summary>
public class ShopService : IShopService
{
    private readonly IShopRepository _repository;

    public ShopService(IShopRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ShopDto>> GetAllAsync()
    {
        // 1) Ask repository for raw entities from the DB
        IReadOnlyList<Shops> shops = await _repository.GetAllAsync();

        // 2) Map entity -> DTO (only fields we want to expose)
        return shops
            .Select(s => new ShopDto
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Language = s.Language
            })
            .ToList();
    }
}
