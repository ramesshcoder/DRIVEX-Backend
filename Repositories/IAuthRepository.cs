using Drivex.Domain.Users;

namespace Drivex.Repositories
{
    public interface IAuthRepository
    {
        public Task<int> SignupAsync(User request );
        public Task<User> GetUserAsync(string email);
    }
}
