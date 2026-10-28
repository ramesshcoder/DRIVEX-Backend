using Drivex.Domain.Cars;
using Drivex.Repositories;

namespace Drivex.Services.Cars;

public class CarService : ICarService
{
    private ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public Task<List<Car>> GetAllCarsAsync(CancellationToken cancellationToken = default)
    {
        return _carRepository.GetAllCarsAsync(cancellationToken);
    }

    public Task<Car?> GetCarByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _carRepository.GetCarByIdAsync(id, cancellationToken);

    }
}
