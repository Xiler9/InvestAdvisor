using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Application.DTOs;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Services
{
    public interface INoteService
    {
        public Task<Note> CreateNoteAsync(CreateNoteRequest createNoteRequest, int userId);
        public Task<Note> GetNoteAsync(int noteId, int userId);
        public Task<List<Note>> GetNotesAsync(GetNotesRequest getNotesRequest);
        public Task DeleteNoteAsync(int noteId);
    }
}