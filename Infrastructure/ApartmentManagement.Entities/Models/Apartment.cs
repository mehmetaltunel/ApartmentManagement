namespace ApartmentManagement.Entities.Models;

public class Apartment : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int NumberOfUnits { get; set; }
    public int NumberOfFloors { get; set; }
    public string Address { get; set; }
}