using Drivex.Domain.Users;
using Drivex.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Drivex.Service
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;

        public AuthService(IAuthRepository authRepository,
              IUserRepository userRepository)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
        }

        public async Task<int> Signup(string username, string password, string Email,
            string Phone, string Role)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new ValidationException("Email is required");
            }

            bool emailAlreadyExists = await _userRepository.CheckEmailExistAsync(Email);

            if (emailAlreadyExists)
            {
                throw new ValidationException("Email is already registered");
            }


            var resut = _authRepository.SignupAsync(
                new User
                {
                    Email = Email,
                    Name = username,
                    Phone = Phone,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                    Role = Role
                }
                );
            return resut.Result;

        }
    }
}
