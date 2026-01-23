namespace backend.DTO;

/// <summary>
/// DTO = Data Transfer Object for a viisits.
/// This is what we send back to the frontend.
/// </summary>
public class VisitsDto
{
    public string Customer_Id { get; set; } = string.Empty;
    public string Shop_Id { get; set; } = string.Empty;
    public string Barber_Id { get; set; } = string.Empty;
}