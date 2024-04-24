using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;
[ApiController]
[Route("[controller]")]
public class SchoolarLevelsController : ControllerBase
{
    private readonly ISchoolarLevelsRepo _schoolarLevelsRepo;
    
    public SchoolarLevelsController(ISchoolarLevelsRepo schoolarLevelsRepo)
    {
        _schoolarLevelsRepo = schoolarLevelsRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<SchoolarLevels>> GetAll()
    {
        return await _schoolarLevelsRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SchoolarLevels>> GetById(int id)
    {
        return await _schoolarLevelsRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<SchoolarLevels>> Post(SchoolarLevels schoolarLevels)
    {
        var newSchoolarLevel = await _schoolarLevelsRepo.AddAsync(schoolarLevels);
        return NoContent();
    }

    [HttpPut("{idSchoolarLevel:int}")]
    public async Task<ActionResult> Put(int idSchoolarLevel, [FromBody] SchoolarLevels schoolarLevels)
    {
        var SchoolarLevelUpdate = await _schoolarLevelsRepo.GetByIdAsync(idSchoolarLevel);
        if (SchoolarLevelUpdate == null)
            return NotFound();

        SchoolarLevelUpdate.nameLevel = schoolarLevels.nameLevel;
        
        await _schoolarLevelsRepo.UpdateAsync(SchoolarLevelUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var SchoolarLeveltoDelete = await _schoolarLevelsRepo.GetByIdAsync(id);
        if (SchoolarLeveltoDelete == null)
            return NotFound();
        await _schoolarLevelsRepo.DeleteAsync(SchoolarLeveltoDelete.idSchoolarLevel);
        return NoContent();
    }
}