namespace Drivex.Service
{
    public interface IAuthService
    {
        Task<int> Signup(string username, string password,string email, string Phone,string Role);
    }
}
