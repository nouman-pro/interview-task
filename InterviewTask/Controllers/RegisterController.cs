using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Register;
using Services.Services.Register.DTOs;

namespace InterviewTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(RegisterRequestModel request)
        {

            return Ok(await _registerService.SignUp(request));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {

            return Ok(await _registerService.Login(request));
        }
    }
}
