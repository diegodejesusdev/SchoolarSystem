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
        var sql = "SELECT * FROM SubLevels";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<SubLevels>(sql);
            return result;
        }
    }

    public async Task<SubLevels> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM SubLevels WHERE idSublevel = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<SubLevels>(sql,new {Id = id});
            return result;
        }
    }

    public async Task<SubLevels> AddAsync(SubLevels entity)
    {
        var sql = "INSERT INTO SubLevels(nameSublevel, yearSublevel) VALUES (@nameSublevel, @yearSublevel)";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, entity);
            return entity;
        }
    }

    public async Task UpdateAsync(SubLevels entity)
    {
        var sql = "UPDATE SubLevels SET nameSublevel = @nameSublevel, yearSublevel = @yearSublevel WHERE idSublevel = @idSublevel";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, entity);
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