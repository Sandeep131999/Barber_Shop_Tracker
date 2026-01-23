namespace backend.Models;

public class Visitor
{

    public Guid CustomerId { get; set; } 

    public Guid ShopId { get; set; } = Guid.Parse("0118bf98-bace-4d3f-b22b-a9cc4a741c06");

    public Guid BarberId { get; set; }= Guid.Parse("6e0c9cda-cdb1-49a9-9d20-2b8cbb8901f6");

    public string Status { get; set; } = "WAITING";

    public DateTime EntryTime { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }
}