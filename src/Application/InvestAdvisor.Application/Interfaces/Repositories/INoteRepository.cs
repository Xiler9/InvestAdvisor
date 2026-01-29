using InvestAdvisor.Domain.Enumerators;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Interfaces.Repositories
{
    public interface INoteRepository
    {
        public Task<Note> CreateNoteAsync(Note note);
        public Task<List<Note>> GetNotesAsync(NoteCategory category);
        public Task<Note> GetNoteAsync(int noteId);
        public Task DeleteNoteAsync(int noteId);
    }
}