using Frontend.Models;

namespace Frontend.Services;

public interface ISchoolarLevelsService
{
    public Task<List<SchoolarLevels>> GetSchoolarLevels();
    public Task<SchoolarLevels>GetShoolarLevel(int id);
    public Task <SchoolarLevels> AddSchoolarLevel(SchoolarLevels schoolarLevel);
    public Task UpdateSchoolarLevel(int id, SchoolarLevels schoolarLevel);
    public Task DeleteSchoolarLevel(int id);
}