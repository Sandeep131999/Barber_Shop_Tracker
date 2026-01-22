namespace backend.DTO;

/// <summary>
/// DTO = Data Transfer Object for a shop.
/// This is what we send back to the frontend.
/// </summary>
public class CustomerDto
{
    public string Phone { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
}

