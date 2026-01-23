namespace backend.Models;

/// <summary>
/// Customer model - represents a customer who visits barber shops
/// </summary>
public class Customers
{
    public string Phone { get; set; }= string.Empty;
    public string Name { get; set; }= string.Empty;
    public int NoOfVisits { get; set; }
    public string RecentVisitDate { get; set; }= string.Empty;
    public string LastVerified { get; set; }= string.Empty;
    public string UpdatedAt { get; set; }= string.Empty;
}