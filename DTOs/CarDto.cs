namespace Drivex.DTOs.Cars;

// DTOs/CarDto.cs
public class CarDto
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
    public string BrandName { get; set; } = string.Empty;
    public string? BrandDescription { get; set; }

    // Category
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? CategoryDescription { get; set; }
}
