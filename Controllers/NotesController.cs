using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    private readonly INotesRepo _notesRepo;

    public NotesController(INotesRepo notesRepo)
    {
        _notesRepo = notesRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<Notes>> GetAll()
    {
        return await _notesRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Notes>> GetById(int id)
    {
        return await _notesRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Notes>> Post(Notes notes)
    {
        var newNote = await _notesRepo.AddAsync(notes);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Notes notes)
    {
        var NotesUpdate = await _notesRepo.GetByIdAsync(id);
        if (NotesUpdate == null)
            return NotFound();
        await _notesRepo.UpdateAsync(notes);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var NotesDelete = await _notesRepo.GetByIdAsync(id);
        if (NotesDelete == null)
            return NotFound();
        await _notesRepo.DeleteAsync(NotesDelete.idNote);
        return NoContent();
    }



}

