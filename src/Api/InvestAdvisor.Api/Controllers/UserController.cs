using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestAdvisor.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserRequest createUserRequest)
        {
            try
            {
                var userResponse = await _userService.CreateUserAsync(createUserRequest);

                _logger.LogInformation("Профиль успешно создан");

                return Ok(userResponse);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Нельзя создать пустой профиль");

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось оздать профиль");

                return BadRequest(ex);
            }
        }
    }
}