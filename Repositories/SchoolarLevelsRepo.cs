using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class SchoolarLevelsRepo : ISchoolarLevelsRepo
{
    private readonly string? _connectionString;

    public SchoolarLevelsRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    
    public async Task<IEnumerable<SchoolarLevels>> GetAllASync()
    {
        var sql = "SELECT * FROM SchoolarLevels";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<SchoolarLevels>(sql);
            return result;
        }
    }
    
    public async Task<SchoolarLevels> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM SchoolarLevels WHERE idSchoolarLevel = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result =  await connection.QuerySingleOrDefaultAsync<SchoolarLevels>(sql, new {Id = id});
            return result;
        }
    }

    public async Task<int> AddAsync(SchoolarLevels entity)
    {
        var sql = "INSERT INTO SchoolarLevels(nameLevel) VALUES (@nameLevel);";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(SchoolarLevels entity)
    {
        var sql = "UPDATE SchoolarLevels SET nameLevel = @nameLevel WHERE idSchoolarLevel = @idSchoolarLevel";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM SchoolarLevels WHERE idSchoolarLevel = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
    }
}

