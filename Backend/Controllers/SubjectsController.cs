using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;
[ApiController]
[Route("[controller]")]
public class SubjectsController : ControllerBase
{
    private readonly ISubjectsRepo _subjectsRepo;
    
    public SubjectsController(ISubjectsRepo subjectsRepo)
    {
        _subjectsRepo = subjectsRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<Subjects>> GetAll()
    {
        return await _subjectsRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Subjects>> GetById(int id)
    {
        return await _subjectsRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Subjects>> Post(Subjects subjects)
    {
        var newSubject = await _subjectsRepo.AddAsync(subjects);
        return NoContent();
    }

    [HttpPut("{idSubject:int}")]
    public async Task<ActionResult> Put(int idSubject, [FromBody] Subjects subjects)
    {
        var SubjectUpdate = await _subjectsRepo.GetByIdAsync(idSubject);
        if (SubjectUpdate == null)
            return NotFound();

        SubjectUpdate.nameSubject = subjects.nameSubject;
        SubjectUpdate.infoSubject = subjects.infoSubject;
        
        await _subjectsRepo.UpdateAsync(SubjectUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var SubjecttoDelete = await _subjectsRepo.GetByIdAsync(id);
        if (SubjecttoDelete == null)
            return NotFound();
        await _subjectsRepo.DeleteAsync(SubjecttoDelete.idSubject);
        return NoContent();
    }
}