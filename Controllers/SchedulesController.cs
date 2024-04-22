using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;

[ApiController]
[Route("[controller]")]
public class SchedulesController : ControllerBase
{
    private readonly ISchedulesRepo _schedulesRepo;

    public SchedulesController(ISchedulesRepo schedulesRepo)
    {
        _schedulesRepo = schedulesRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<Schedules>> GetAll()
    {
        return await _schedulesRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Schedules>> GetById(int id)
    {
        return await _schedulesRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Schedules>> Post(Schedules schedules)
    {
        var newSchedule = await _schedulesRepo.AddAsync(schedules);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Schedules schedules)
    {
        var ScheduleUpdate = await _schedulesRepo.GetByIdAsync(id);
        if (ScheduleUpdate == null)
            return NotFound();
        await _schedulesRepo.UpdateAsync(schedules);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var ScheduleDelete = await _schedulesRepo.GetByIdAsync(id);
        if (ScheduleDelete == null)
            return NotFound();
        await _schedulesRepo.DeleteAsync(ScheduleDelete.idSchedule);
        return NoContent();
    }
}

