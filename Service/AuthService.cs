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
                               string Phone, string Role, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(Email))
                throw new ValidationException("Email is required");

            if (string.IsNullOrWhiteSpace(password))
                throw new ValidationException("Password is required");

            if (password != confirmPassword)
                throw new ValidationException("Password and confirm password do not match");

            bool emailAlreadyExists = await _userRepository.CheckEmailExistAsync(Email);

            if (emailAlreadyExists)
                throw new ValidationException("Email is already registered");

            var user = new User
            {
                Email = Email,
                Name = username,
                Phone = Phone,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = Role
            };

            return await _authRepository.SignupAsync(user);
        }


        public async Task<int> LoginAsync(LoginRequest request)
        {
            var user = await _authRepository.GetUserAsync(request.Email);


            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            bool IsPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (IsPasswordValid)
            {
                return user.Id;
            }
            throw new UnauthorizedAccessException("Invalid email or password.");

        }
    }
}
