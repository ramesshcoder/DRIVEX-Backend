using Drivex.Data;
using Drivex.Domain.Users;

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

    }

}
