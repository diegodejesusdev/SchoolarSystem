using Frontend.Models;

namespace Frontend.Services;

public interface ISubLevelsService
{
    public Task<List<SubLevels>> GetSubLevels();
}