using Microsoft.AspNetCore.Mvc;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Controllers;
[ApiController]
[Route("scholar/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentsRepo _studentsRepo;
    
    public StudentsController(IStudentsRepo studentsRepo)
    {
        _studentsRepo = studentsRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<Students>> GetAll()
    {
        return await _studentsRepo.GetAllASync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Students>> GetById(int id)
    {
        return await _studentsRepo.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Students>> Post(Students students)
    {
        var newStudent = await _studentsRepo.AddAsync(students);
        return NoContent();
    }

    [HttpPut("{idStudent:int}")]
    public async Task<ActionResult> Put(int idStudent, [FromBody] Students students)
    {
        var StudentsUpdate = await _studentsRepo.GetByIdAsync(idStudent);
        if (StudentsUpdate == null) 
            return NotFound();

        StudentsUpdate.nameStudent = students.nameStudent;
        StudentsUpdate.ccStudent = students.ccStudent;
        StudentsUpdate.emailStudent = students.emailStudent;
        StudentsUpdate.phoneStudent = students.phoneStudent;
        StudentsUpdate.idSchoolarLevelS = students.idSchoolarLevelS;
        
        await _studentsRepo.UpdateAsync(StudentsUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var StudentstoDelete = await _studentsRepo.GetByIdAsync(id);
        if (StudentstoDelete == null)
            return NotFound();
        await _studentsRepo.DeleteAsync(StudentstoDelete.idStudent);
        return NoContent();
    }
}