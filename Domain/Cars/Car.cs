namespace Drivex.Domain.Cars;

// DTOs/CarDto.cs
public class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public string Transmission { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty;
    public int Seats { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; }

    // Brand
    public int BrandId { get; set; }

    // Category
    public int CategoryId { get; set; }

    public Brand Brand { get; set; } = null!;
    public Category Category { get; set; } = null!;
}
