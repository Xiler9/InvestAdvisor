using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Repositories
{
    public interface INoteRepository
    {
        public Task<Note> CreateNoteAsync(Note note);
        public Task<List<Note>> GetAllNotesAsync();
        public Task<Note> GetNoteAsync(int noteId);
        public Task DeleteNoteAsync(int noteId);
    }
}