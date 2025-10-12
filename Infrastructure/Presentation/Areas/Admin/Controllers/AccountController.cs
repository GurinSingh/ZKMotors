using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Account;
using ZK.Domain.Entities.Users;
using ZK.Services.Abstractions;

namespace ZK.Presentation.Areas.Admin.Controllers
{
    [ApiController]
    [Route("admin/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AccountController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequest, CancellationToken cancellationToken)
        {
            var result = await this._serviceManager.AuthenticationService.SignInAsync(loginRequest, cancellationToken);

            if (result == null)
                return Unauthorized();

            return result;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterAsync(RegisterRequestDTO registerRequest, CancellationToken cancellationToken)
        {
            if (registerRequest == null)
                throw new ArgumentNullException(nameof(registerRequest));


            var result = await this._serviceManager.AuthenticationService.RegisterAsync(registerRequest, cancellationToken);
            if (!result)
                return BadRequest("User registration failed.");
            return Ok("User registered successfully.");
        }
    }
}
