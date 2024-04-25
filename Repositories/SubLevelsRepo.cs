using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class SubLevelsRepo : ISublevelsRepo
{
    private readonly string? _connectionString;
    public SubLevelsRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    
    public async Task<IEnumerable<SubLevels>> GetAllASync()
    {
        var sql = "SELECT sl.*, sh.* FROM SubLevels sl " +
                  "JOIN SchoolarLevels sh ON sl.idSchLevelS = sh.idSchoolarLevel";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<SubLevels, SchoolarLevels, SubLevels>(sql,
                (subLevels, schoolarLevels) =>
                {
                    subLevels.SchoolarLevels = schoolarLevels;
                    return subLevels;
                }, splitOn: "idSchoolarLevel");
            return result;
        }
    }

    public async Task<SubLevels> GetByIdAsync(int id)
    {
        var sql = "SELECT sl.*, sh.* FROM SubLevels sl " +
                  "JOIN SchoolarLevels sh ON sl.idSchLevelS = sh.idSchoolarLevel WHERE idSublevel = @Id;";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<SubLevels, SchoolarLevels, SubLevels>(sql,
                (subLevels, schoolarLevels) =>
                {
                    subLevels.SchoolarLevels = schoolarLevels;
                    return subLevels;
                }, new {Id = id},splitOn: "idSchoolarLevel");
            return result.FirstOrDefault();
        }
    }

    public async Task<int> AddAsync(SubLevels entity)
    {
        var sql = "INSERT INTO SubLevels(nameSublevel, yearSublevel, idSchLevelS) VALUES (@nameSublevel, @yearSublevel, @idSchLevelS);";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(SubLevels entity)
    {
        var sql = "UPDATE SubLevels SET nameSublevel = @nameSublevel, yearSublevel = @yearSublevel, idSchLevelS = @idSchLevelS WHERE idSublevel = @idSublevel";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM SubLevels WHERE idSublevel = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
    }
}