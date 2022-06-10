using Microsoft.AspNetCore.Mvc;
using NoteSandbax.Interfaces;
using NoteSandbax.Models;
using NoteSandbax.ViewModels;

namespace NoteSandbax.ViewComponents
{
    public class NoteDetails : ViewComponent
    {
        private readonly INotesRepository _noteRepository;
        
        public NoteDetails(INotesRepository notesRepository)
        {
            _noteRepository = notesRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            Notes note = await _noteRepository.GetNote(id);

            var viewNote = new NoteDetailsViewModel
            {
                note = note
            };

            return View(viewNote);

        }


    }
}
