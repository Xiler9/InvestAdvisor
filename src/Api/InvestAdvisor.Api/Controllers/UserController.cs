using InvestAdvisor.Api.Models;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InvestAdvisor.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        private readonly string _secret;

        public UserController(IUserService userService, ILogger<UserController> logger, IOptions<AuthSettings> options)
        {
            _userService = userService;
            _logger = logger;
            _secret = options.Value.Secret;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserRequest createUserRequest)
        {
            try
            {
                var userResponse = await _userService.CreateUserAsync(createUserRequest);

                _logger.LogInformation("Пользователь успешно создан");

                return Ok(userResponse);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Нельзя создать пустого пользователя");

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось создать пользователя");

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginRequest userLoginRequest)
        {
            try
            {
                var token = await _userService.UserLoginAsync(userLoginRequest, _secret);

                _logger.LogInformation("Токен успешно создан");

                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось создать токен");

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [CheckAccess]
        [Route("get")]
        public async Task<IActionResult> GetUserAsync()
        {
            try
            {
                var userId = int.Parse(HttpContext.Items["userId"].ToString());

                var userResponse = await _userService.GetUserAsync(userId);

                _logger.LogInformation("Пользователь с id - {0} успешно получен", userId);

                return Ok(userResponse);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Неудалось найти пользователя");

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось получить пользователя");

                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "User,Admin")]
        [CheckAccess]
        [Route("delete")]
        public async Task<IActionResult> DeleteUserAsync()
        {
            try
            {
                var userId = int.Parse(HttpContext.Items["userId"].ToString());

                await _userService.DeleteUserAsync(userId);

                _logger.LogInformation("Пользователь с id - {0} успешно удален", userId);

                return Ok();
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Неудалось найти пользователя");

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось удалить пользователя");

                return BadRequest(ex);
            }
        }
    }
}