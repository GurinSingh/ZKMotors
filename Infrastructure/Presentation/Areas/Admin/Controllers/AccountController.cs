using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZK.Contracts.DTOs.Account;
using ZK.Domain.Entities.Users;
using ZK.Services.Abstractions;

namespace ZK.Presentation.Areas.Admin.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AccountController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> LoginAsync(LoginRequestDTO loginRequest, CancellationToken cancellationToken)
        {
            var result = await this._serviceManager.AuthenticationService.SignInAsync(loginRequest, cancellationToken);

            if (result == null)
                return Unauthorized();

            return result;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterRequestDTO registerRequest, CancellationToken cancellationToken)
        {
            if (registerRequest == null)
                throw new ArgumentNullException(nameof(registerRequest));

            

            var result = await this._serviceManager.AuthenticationService.RegisterAsync(registerRequest, cancellationToken);
            if (!result)
                return BadRequest("User registration failed.");
            return Ok("User registered successfully.");
        }

        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult> GetCurrentUserAsync(CancellationToken cancellationToken)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                return Unauthorized();
            }
            var user = await this._serviceManager.UserService.GetByIdAsync(userId, cancellationToken);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
