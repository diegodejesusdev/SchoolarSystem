using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class TeachersRepo : ITeachersRepo
{
    private readonly string? _connectionString;
    public TeachersRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    
    public async Task<IEnumerable<Teachers>> GetAllASync()
    {
        var sql = "SELECT * FROM Teachers";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Teachers>(sql);
            return result;
        }
    }

    public async Task<Teachers> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Teachers WHERE idTeacher=@Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Teachers>(sql, new { Id = id });
            return result;
        }
    }

    public async Task<Teachers> AddAsync(Teachers entity)
    {
        var sql = "INSERT INTO Teachers(nameTeacher, ccTeacher, emailTeacher, phoneTeacher, infoTeacher) " +
                  "VALUES(@nameTeacher, @ccTeacher, @emailTeacher, @phoneTeacher, @infoTeacher)";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, entity);
            return entity;
        }
    }

    public async Task UpdateAsync(Teachers entity)
    {
        var sql = "UPDATE Teachers SET nameTeacher = @nameTeacher, ccTeacher = @ccTeacher, emailTeacher = @emailTeacher, " +
                  "phoneTeacher = @phoneTeacher, infoTeacher = @infoTeacher WHERE idTeacher = @idTeacher";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, entity);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM Teachers WHERE idTeacher = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}