using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoteSandbax.Data;
using NoteSandbax.Interfaces;
using NoteSandbax.Models;
using NoteSandbax.ViewModels;

namespace NoteSandbax.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepository _noteRepository;

        public NotesController(INotesRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            IEnumerable<Notes> _notes = await _noteRepository.GetAll();

            if(_notes == null)
            {
                return NotFound();
            }

            var viewModel = new MainViewViewModel
            {
                notes = _notes
            };
        
            return View(viewModel);
        
        
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Notes note = await _noteRepository.GetNote(id);
            
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,body")] Notes notes)
        {
            if (ModelState.IsValid)
            {
                _noteRepository.Add(notes);
                return RedirectToAction(nameof(Index));
            }
            return View(notes);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (_noteRepository.NoteExists(id) == false)
            {
                return NotFound(); //   make my own not found page!
            }

            var notes = await _noteRepository.GetNote(id);
            if (notes == null)
            {
                return NotFound();
            }
            return View(notes);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,body")] Notes notes)
        {
            if (id != notes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _noteRepository.Update(notes);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotesExists(notes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(notes);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_noteRepository.NoteExists(id) == false)
            {
                return NotFound(); //   make my own not found page!
            }

            var notes = await _noteRepository.GetNote(id);
            if (notes == null)
            {
                return NotFound();
            }

            return View(notes);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_noteRepository.NoteExists(id) == false)
            {
                return Problem("Entity set 'AppDbContext.Notes'  is null.");
            }
            var notes = await _noteRepository.GetNote(id);
            if (notes != null)
            {
                _noteRepository.Delete(notes);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NotesExists(int id)
        {
            return _noteRepository.NoteExists(id);
        }

        public IActionResult GetNoteDetailsViewComponent(int id)
        {
            return ViewComponent("NoteDetails", id);
        }

        //  Route annotations aren't needed
        //[Route("Notes/NoteDetails")]
        //[Route("Notes/NoteDetails/{id?}")]
        public PartialViewResult NoteDetails(int id)
        {
            Thread.Sleep(500);
            Notes note =  _noteRepository.GetSingle(id);
            return PartialView("_NoteDetails", note);
        }


        // GET: Notes/GetEdit/5
        public async Task<IActionResult> GetEdit(int id)
        {
            if (_noteRepository.NoteExists(id) == false)
            {
                return NotFound(); //   make my own not found page!
            }

            var notes = await _noteRepository.GetNote(id);
            if (notes == null)
            {
                return NotFound();
            }
            Thread.Sleep(500);
            return PartialView("_NoteEdit", notes);
        }


        // GET: Notes/GetDelete/5
        public async Task<IActionResult> GetDelete(int id)
        {
            if (_noteRepository.NoteExists(id) == false)
            {
                return NotFound(); //   make my own not found page!
            }

            var notes = await _noteRepository.GetNote(id);
            if (notes == null)
            {
                return NotFound();
            }
            Thread.Sleep(500);
            return PartialView("_NoteDelete", notes);
        }

        // GET: Notes/GetCreate
        public IActionResult GetCreate()
        {
            Thread.Sleep(500);
            return PartialView("_NoteCreate");
        }

    }
}
