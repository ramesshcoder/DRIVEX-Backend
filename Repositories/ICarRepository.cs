using Drivex.Domain.Cars;

namespace Drivex.Repositories;

public interface ICarRepository
{
    Task<List<Car>> GetAllCarsAsync(CancellationToken cancellationToken = default);

    Task<Car?> GetCarByIdAsync(int id, CancellationToken cancellationToken = default);
}
