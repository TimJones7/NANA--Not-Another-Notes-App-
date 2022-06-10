using Microsoft.EntityFrameworkCore;
using NoteSandbax.Data;
using NoteSandbax.Interfaces;
using NoteSandbax.Models;

namespace NoteSandbax.Repository
{
    public class NotesRepository : INotesRepository 
    {
        private readonly AppDbContext _context;

        public NotesRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Notes note)
        {
            _context.Notes.Add(note);
            return Save();
        }

        public bool Delete(Notes note)
        {
            _context.Notes.Remove(note);
            return Save();
        }

        public async Task<IEnumerable<Notes>> GetAll()
        {
            
            return await _context.Notes.ToListAsync();
        }

        public async Task<Notes> GetNote(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public Notes GetSingle(int id)
        {
            return _context.Notes.Find(id);
        }



        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Notes note)
        {
            _context.Notes.Update(note);
            return Save();
        }

        public  bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }      
    }
}
