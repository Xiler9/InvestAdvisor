using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Services
{
    public interface INoteService
    {
        public Task<Note> CreateNoteAsync(CreateNoteRequest createNoteRequest);
        public Task<Note> GetNoteAsync(int noteId);
        public Task<List<Note>> GetNotesAsync();
        public Task DeleteNoteAsync(int noteId);
    }
}