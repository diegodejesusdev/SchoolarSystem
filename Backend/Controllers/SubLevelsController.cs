using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;
[ApiController]
[Route("[controller]")]
public class SubLevelsController : ControllerBase
{
    private readonly ISublevelsRepo _sublevelsRepo;
    
    public SubLevelsController(ISublevelsRepo sublevelsRepo)
    {
        _sublevelsRepo = sublevelsRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<SubLevels>> GetAll()
    {
        return await _sublevelsRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SubLevels>> GetById(int id)
    {
        return await _sublevelsRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<SubLevels>> Post(SubLevels subLevels)
    {
        var newSubLevel = await _sublevelsRepo.AddAsync(subLevels);
        return NoContent();
    }

    [HttpPut("{idSublevel:int}")]
    public async Task<ActionResult> Put(int idSublevel, [FromBody] SubLevels subLevels)
    {
        var SubLevelUpdate = await _sublevelsRepo.GetByIdAsync(idSublevel);
        if (SubLevelUpdate == null)
            return NotFound();

        SubLevelUpdate.nameSublevel = subLevels.nameSublevel;
        SubLevelUpdate.yearSublevel = subLevels.yearSublevel;
        
        await _sublevelsRepo.UpdateAsync(SubLevelUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var SubLevelUpdate = await _sublevelsRepo.GetByIdAsync(id);
        if (SubLevelUpdate == null)
            return NotFound();
        await _sublevelsRepo.DeleteAsync(SubLevelUpdate.idSublevel);
        return NoContent();
    }
}