using NoteSandbax.Models;

namespace NoteSandbax.Interfaces
{
    public interface INotesRepository
    {
        //  for notes controller to resolve Index view.
        Task<IEnumerable<Notes>> GetAll();

        //  To be used by view component to return partial view of singular Note.
        Task<Notes> GetNote(int id);

        Notes GetSingle(int id);

        //   Essential CRUDs
        bool Add(Notes note);

        bool Update(Notes note);

        bool Delete(Notes note);

        bool NoteExists(int id);

        bool Save();
    }
}
