using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;
[ApiController]
[Route("[controller]")]
public class SubjectFullController : ControllerBase
{
    private readonly ISubjectFullRepo _subjectFullRepo;
    
    public SubjectFullController(ISubjectFullRepo subjectFullRepo)
    {
        _subjectFullRepo = subjectFullRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<SubjectFull>> GetAll()
    {
        return await _subjectFullRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SubjectFull>> GetById(int id)
    {
        return await _subjectFullRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<SubjectFull>> Post(SubjectFull subjectFull)
    {
        var newSubjectFull = await _subjectFullRepo.AddAsync(subjectFull);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, SubjectFull subjectFull)
    {
        var SubjectFullUpdate = await _subjectFullRepo.GetByIdAsync(id);
        if (SubjectFullUpdate == null)
            return NotFound();
        await _subjectFullRepo.UpdateAsync(subjectFull);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var SubjectFulltoDelete = await _subjectFullRepo.GetByIdAsync(id);
        if (SubjectFulltoDelete == null)
            return NotFound();
        await _subjectFullRepo.DeleteAsync(SubjectFulltoDelete.idSubjectFull);
        return NoContent();
    }
}