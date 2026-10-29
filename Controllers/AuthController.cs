using Drivex.DTOs;
using Drivex.Service;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Drivex.Controllers

{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _authService;
        private readonly IMapper _mapper;
       public AuthController(AuthService authService,
            IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        [HttpPost("sign-up")]
        public async Task<ActionResult<int>> Signup(SignupRequestDto signupRequest)
        {

            var result = await _authService.Signup(signupRequest.Name, signupRequest.Password,
                signupRequest.Email, signupRequest.Email, signupRequest.Role);
            return Ok(result);
        }
    }
}
