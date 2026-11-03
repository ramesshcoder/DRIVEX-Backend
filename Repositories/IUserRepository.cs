namespace Drivex.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckEmailExistAsync(string email);
    }
}
