using Drivex.Domain.Users;
using Drivex.DTOs;

namespace Drivex.Repositories
{
    public interface IAuthRepository
    {
        public Task<int> SignupAsync(User request );
    }
}
