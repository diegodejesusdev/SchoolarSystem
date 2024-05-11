using Frontend.Models;

namespace Frontend.Services;

public interface IStudentsService
{
    public Task<List<Students>> GetStudents();
    public Task<Students>GetStudent(int id);
    public Task <Students> AddStudent(Students students);
    public Task UpdateStudent(int id, Students students);
    public Task DeleteStudent(int id);
}