using Drivex.Data;
using Drivex.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Drivex.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DBContext _dbcontext;

        public AuthRepository(DBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> SignupAsync(User user)
        {
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await  _dbcontext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

    }

}
