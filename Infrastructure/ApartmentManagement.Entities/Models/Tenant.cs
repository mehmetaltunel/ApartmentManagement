namespace ApartmentManagement.Entities.Models;

public class Tenant : BaseEntity
{
    public int ApartmentId { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public DateTime MoveInDate { get; set; }
    public DateTime? MoveOutDate { get; set; }
    public int UserId { get; set; }
    public int NumberOfUnit { get; set; }
}