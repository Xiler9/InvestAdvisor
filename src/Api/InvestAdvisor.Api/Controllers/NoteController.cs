using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InvestAdvisor.Api.Controllers
{
    [Route("api")]
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

        [HttpPost("note/create")]
        public async Task<IActionResult> CreateNoteAsync([FromBody]CreateNoteRequest createNoteRequest)
        {
            try
            {
                var noteResponse = await _noteService.CreateNoteAsync(createNoteRequest);

                _logger.LogInformation("Запись успешно создана");

                return Ok(noteResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неудалось создать запись");

                return BadRequest(ex);
            }
        }
        
        [HttpGet("note/get/{noteId}")]
        public async Task<IActionResult> GetNoteAsync([FromQuery, Range(1, int.MaxValue, ErrorMessage = "noteId должен быть больше нуля")] int noteId)
        {
            try
            {
                var noteResponse = await _noteService.GetNoteAsync(noteId);

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

        [HttpGet("note/get")]
        public async Task<IActionResult> GetNotesAsync()
        {
            try
            {
                var notes = _noteService.GetNotesAsync();

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

        [HttpDelete("note/delete/{noteId}")]
        public async Task<IActionResult> DeleteNoteAsync([FromQuery, Range(1, int.MaxValue, ErrorMessage = "noteId должен быть больше нуля")] int noteId)
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