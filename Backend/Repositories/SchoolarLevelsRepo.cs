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

    public async Task<SchoolarLevels> AddAsync(SchoolarLevels entity)
    {
        var sql = "INSERT INTO SchoolarLevels(nameLevel, idSublevelSL) VALUES (@nameLevel, @idSublevelSL)";

        var parameters = new
        {
            entity.nameLevel,
            entity.idSublevelSL
        };
        
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, parameters);
            return entity;
        }
    }

    public async Task UpdateAsync(SchoolarLevels entity)
    {
        var sql = "UPDATE SchoolarLevels SET nameLevel = @nameLevel, idSublevelSL = @idSublevelSL " +
                  "WHERE idSchoolarLevel = @idSchoolarLevel";

        var parameters = new
        {
            entity.nameLevel,
            entity.idSublevelSL,
            entity.idSchoolarLevel
        };
        
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, parameters);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM SchoolarLevels WHERE idSchoolarLevel = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}

