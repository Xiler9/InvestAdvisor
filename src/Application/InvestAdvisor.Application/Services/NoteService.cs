using AutoMapper;
using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Application.Interfaces.Services;
using InvestAdvisor.Domain.Enumerators;
using InvestAdvisor.Domain.Models;
using Microsoft.Extensions.Logging;

namespace InvestAdvisor.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly IUserService _userService;

        private readonly IUserRepository _userRepository;

        private readonly INoteRepository _noteRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<NoteService> _logger;

        public NoteService(IUserService userService, INoteRepository noteRepository, IMapper mapper, ILogger<NoteService> logger, IUserRepository userRepository)
        {
            _userService = userService;
            _noteRepository = noteRepository;
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<Note> CreateNoteAsync(CreateNoteRequest createNoteRequest, int userId)
        {
            var note = _mapper.Map<Note>(createNoteRequest);
            
            note.UserId = userId;

            _logger.LogInformation("Маппер для создания записи успешно скопирован");

            note = await _noteRepository.CreateNoteAsync(note);

            return note;
        }

        public async Task<Note> GetNoteAsync(int noteId, int userId)
        {
            var note = await _noteRepository.GetNoteAsync(noteId);

            var user = await _userRepository.GetUserAsync(userId);

            user.Preferences.Add(note.Category);

            return note;
        }

        public async Task<List<Note>> GetNotesAsync(GetNotesRequest getNotesRequest)
        {
            var notes = await _noteRepository.GetNotesAsync(getNotesRequest.Category);

            if (getNotesRequest.Category != NoteCategory.All)
            {
                await _userService.WritePreferenceAsync(getNotesRequest);
            }

            return notes;
        }

        public async Task DeleteNoteAsync(int noteId)
        {
            await _noteRepository.DeleteNoteAsync(noteId);
        }
    }
}