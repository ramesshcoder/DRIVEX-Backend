using Drivex.Domain.Users;
using Drivex.DTOs;
using Drivex.Service;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Drivex.Controllers

{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService,
             IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        [HttpPost("sign-up")]
        public async Task<ActionResult<int>> Signup(SignupRequestDto signupRequest)
        {

            var result = await _authService.Signup(signupRequest.Name, signupRequest.Password,
                signupRequest.Email, signupRequest.Phone, signupRequest.Role, signupRequest.ConfirmPassword);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<int>> Login(LoginRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var result = await _authService.LoginAsync(_mapper.Map<LoginRequest>(request));
            return Ok(result);
        }
    }
}

