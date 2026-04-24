using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InvestAdvisor.Api.Controllers
{
    [Route("comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _commentService = commentService;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CreateCommentRequest createCommentRequest)
        {
            try
            {
                var userId = int.Parse(HttpContext.Items["userId"].ToString());

                var commentResponse = await _commentService.CreateCommentAsync(createCommentRequest, userId);

                _logger.LogInformation("Коммент успешно создана");

                return Ok(commentResponse);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Неудалось создать пустой коммент");

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось создать коммент");

                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("delete/{commentId}")]
        public async Task<IActionResult> DeleteCommentAsync([FromRoute, Range(1, int.MaxValue, ErrorMessage = "commentId должен быть больше нуля")] int commentId)
        {
            try
            {
                await _commentService.DeleteCommentAsync(commentId);

                _logger.LogInformation("Запись с id - {0} успешно удалена", commentId);

                return Ok();
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Неудалось найти комментарий c id - {0}", commentId);

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось удалить комментарий c id - {0}", commentId);

                return BadRequest(ex);
            }
        }
    }
}