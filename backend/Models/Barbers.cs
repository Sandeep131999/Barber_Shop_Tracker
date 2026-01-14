namespace backend.Models;

/// <summary>
/// Barber model - represents a barber who works at a shop
/// </summary>
public class Barbers
{
    public string Id { get; set; } = string.Empty;
    public string ShopId { get; set; } = string.Empty;
    public string Name { get; set; }= string.Empty;
    public string UserId { get; set; }= string.Empty;
    public string PasswordHash { get; set; }= string.Empty;
    public bool IsActive { get; set; }
    public string CreatedAt { get; set; }= string.Empty;
    public string UpdatedAt { get; set; }= string.Empty;
}