using backend.DTO;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

/// <summary>
/// Controller for shop-related API endpoints
/// </summary>
[ApiController]
[Route("[controller]")]
public class ShopsController : ControllerBase
{
    private readonly IShopService _shopService;

    public ShopsController(IShopService shopService)
    {
        _shopService = shopService;
    }

    /// <summary>
    /// Returns all shops from PostgreSQL using DTO/Repository/Service pattern
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ShopDto>>> GetShops()
    {
        var result = await _shopService.GetAllAsync();
        return Ok(result);
    }
}
