using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;
[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly IClassRepo _classRepo;

    public ClassController(IClassRepo classRepo)
    {
        _classRepo = classRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<Class>> GetAll()
    {
        return await _classRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Class>> GetById(int id)
    {
        return await _classRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Class>> Post(Class clss)
    {
        var newClass = await _classRepo.AddAsync(clss);
        return NoContent();
    }

    [HttpPut("{idClass:int}")]
    public async Task<ActionResult> Put(int idClass, [FromBody] Class clss)
    {
        var ClassUpdate = await _classRepo.GetByIdAsync(idClass);
        if (ClassUpdate == null)
            return NotFound();

        ClassUpdate.classroomClass = clss.classroomClass;
        ClassUpdate.idSchoolarLevelC = clss.idSchoolarLevelC;
        ClassUpdate.idSubjectFullC = clss.idSubjectFullC;
        
        await _classRepo.UpdateAsync(ClassUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var ClassDelete = await _classRepo.GetByIdAsync(id);
        if (ClassDelete == null)
            return NotFound();
        await _classRepo.DeleteAsync(ClassDelete.idClass);
        return NoContent();
    }
}