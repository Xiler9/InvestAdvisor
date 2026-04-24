using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InvestAdvisor.Api.Controllers
{
    [Route("note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        private readonly ILogger<NoteController> _logger;

        public NoteController(INoteService userService, ILogger<NoteController> logger)
        {
            _noteService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateNoteAsync([FromBody]CreateNoteRequest createNoteRequest)
        {
            try
            {
                var userId = int.Parse(HttpContext.Items["userId"].ToString());

                var noteResponse = await _noteService.CreateNoteAsync(createNoteRequest, userId);

                _logger.LogInformation("Запись успешно создана");

                return Ok(noteResponse);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Неудалось создать пустую запись");

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось создать запись");

                return BadRequest(ex);
            }
        }
        
        [HttpGet]
        [Route("get/{noteId}")]
        public async Task<IActionResult> GetNoteAsync([FromRoute, Range(1, int.MaxValue, ErrorMessage = "noteId должен быть больше нуля")] int noteId)
        {
            try
            {
                var userId = int.Parse(HttpContext.Items["userId"].ToString());

                var noteResponse = await _noteService.GetNoteAsync(noteId, userId);

                _logger.LogInformation("Запись с id - {0} успешно получена", noteId);

                return Ok(noteResponse);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Неудалось найти запись c id - {0}", noteId);

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось получить запись c id - {0}", noteId);

                return BadRequest(ex);
            }
        }

        //Сделать правильно с userId и системой рекомендацией
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetNotesAsync([FromBody]GetNotesRequest getNotesRequest)
        {
            try
            {
                var notes = _noteService.GetNotesAsync(getNotesRequest);

                _logger.LogInformation("Записи успешно получены");

                return Ok(notes);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Неудалось найти записи");

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось получить записи");

                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("delete/{noteId}")]
        public async Task<IActionResult> DeleteNoteAsync([FromRoute, Range(1, int.MaxValue, ErrorMessage = "noteId должен быть больше нуля")] int noteId)
        {
            try
            {
                await _noteService.DeleteNoteAsync(noteId);

                _logger.LogInformation("Запись с id - {0} успешно удалена", noteId);

                return Ok();
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "Неудалось найти запись c id - {0}", noteId);

                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось удалить запись c id - {0}", noteId);

                return BadRequest(ex);
            }
        }
    }
}