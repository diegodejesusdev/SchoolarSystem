using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;
[ApiController]
[Route("[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeachersRepo _teachersRepo;
    
    public TeachersController(ITeachersRepo teachersRepo)
    {
        _teachersRepo = teachersRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<Teachers>> GetAll()
    {
        return await _teachersRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Teachers>> GetById(int id)
    {
        return await _teachersRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Teachers>> Post(Teachers teachers)
    {
        var newTeacher = await _teachersRepo.AddAsync(teachers);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Teachers teachers)
    {
        var TeacherUpdate = await _teachersRepo.GetByIdAsync(id);
        if (TeacherUpdate == null)
            return NotFound();
        await _teachersRepo.UpdateAsync(teachers);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var TeachertoDelete = await _teachersRepo.GetByIdAsync(id);
        if (TeachertoDelete == null)
            return NotFound();
        await _teachersRepo.DeleteAsync(TeachertoDelete.idTeacher);
        return NoContent();
    }
}