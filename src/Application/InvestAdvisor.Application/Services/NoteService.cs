using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Application.Interfaces.Services;
using InvestAdvisor.Domain.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace InvestAdvisor.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<NoteService> _logger;

        public NoteService(INoteRepository userRepository, IMapper mapper, ILogger<NoteService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Note> CreateNoteAsync(CreateNoteRequest createNoteRequest)
        {
            var note = _mapper.Map<Note>(createNoteRequest);

            _logger.LogInformation("Маппер успешно скопирован");

            note = await _userRepository.CreateNoteAsync(note);

            return note;
        }

        public async Task<Note> GetNoteAsync(int noteId)
        {
            var note = await _userRepository.GetNoteAsync(noteId);

            return note;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            var notes = await _userRepository.GetAllNotesAsync();

            return notes;
        }

        public async Task DeleteNoteAsync(int noteId)
        {
            await _userRepository.DeleteNoteAsync(noteId);
        }
    }
}