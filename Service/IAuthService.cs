using Drivex.Domain.Users;

namespace Drivex.Service
{
    public interface IAuthService
    {
        Task<int> Signup(string username, string password, string email, string Phone, string Role,string confirmPassword);
        Task<int> LoginAsync(LoginRequest request);
    }
}
