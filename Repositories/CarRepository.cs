using Drivex.Data;
using Drivex.Domain.Cars;
using Microsoft.EntityFrameworkCore;

namespace Drivex.Repositories;

public class CarRepository : ICarRepository
{
    private readonly DBContext _context;

    public CarRepository(DBContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetAllCarsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Cars.AsNoTracking().Include(c => c.Brand)
            .Include(c => c.Category).ToListAsync(cancellationToken);
    }

    public async Task<Car?> GetCarByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Cars.AsNoTracking().Include(c => c.Brand)
            .Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
