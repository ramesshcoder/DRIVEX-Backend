using Drivex.Data;
using Microsoft.EntityFrameworkCore;

namespace Drivex.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DBContext _dbContext;

        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email == email);
        }
    }
}
