namespace backend.DTO;

/// <summary>
/// DTO = Data Transfer Object for a shop.
/// This is what we send back to the frontend.
/// </summary>
public class ShopDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
}

