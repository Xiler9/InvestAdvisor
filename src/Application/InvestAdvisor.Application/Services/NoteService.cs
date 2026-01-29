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

        private readonly INoteRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<NoteService> _logger;

        public NoteService(IUserService userService, INoteRepository userRepository, IMapper mapper, ILogger<NoteService> logger)
        {
            _userService = userService;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Note> CreateNoteAsync(CreateNoteRequest createNoteRequest)
        {
            var note = _mapper.Map<Note>(createNoteRequest);

            _logger.LogInformation("Маппер для создания записи успешно скопирован");

            note = await _userRepository.CreateNoteAsync(note);

            return note;
        }

        public async Task<Note> GetNoteAsync(int noteId)
        {
            var note = await _userRepository.GetNoteAsync(noteId);

            return note;
        }

        public async Task<List<Note>> GetNotesAsync(GetNotesRequest getNotesRequest)
        {
            var notes = await _userRepository.GetNotesAsync(getNotesRequest.Category);

            if (getNotesRequest.Category != NoteCategory.All)
            {
                await _userService.WritePreferenceAsync(getNotesRequest);
            }

            return notes;
        }

        public async Task DeleteNoteAsync(int noteId)
        {
            await _userRepository.DeleteNoteAsync(noteId);
        }
    }
}