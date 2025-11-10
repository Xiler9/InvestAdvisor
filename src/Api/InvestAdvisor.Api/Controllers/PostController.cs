using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestAdvisor.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _userService;

        private readonly ILogger<PostController> _logger;

        public PostController(IPostService userService, ILogger<PostController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(CreatePostRequest createPostRequest)
        {
            await _userService.CreatePostAsync(createPostRequest);

            _logger.LogInformation("Пост успешно создан");

            return Created();
        }
    }
}