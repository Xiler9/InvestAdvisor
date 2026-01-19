using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InvestAdvisor.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _appDbContext;

        private readonly ILogger<NoteRepository> _logger;

        public NoteRepository(AppDbContext appDbContext, ILogger<NoteRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Note> CreateNoteAsync(Note note)
        {
            await _appDbContext.Notes.AddAsync(note);

            await _appDbContext.SaveChangesAsync();

            return note;
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            var notes = await _appDbContext.Notes.ToListAsync();

            return notes;
        }

        public async Task<Note> GetNoteAsync(int noteId)
        {
            var note = await _appDbContext.Notes.FindAsync(noteId);

            return note;
        }

        public async Task DeleteNoteAsync(int noteId)
        {
            var note = await GetNoteAsync(noteId);

            _appDbContext.Notes.Remove(note);

            await _appDbContext.SaveChangesAsync();
        }
    }
}