using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class SchedulesRepo : ISchedulesRepo
{
    private readonly string? _connectionString;
    public SchedulesRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    
    public async Task<IEnumerable<Schedules>> GetAllASync()
    {
        var sql = "SELECT * FROM Schedules";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Schedules>(sql);
            return result;
        }
    }

    public async Task<Schedules> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Schedules WHERE idSchedule = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Schedules>(sql, new { Id = id });
            return result;
        }
    }

    public async Task<Schedules> AddAsync(Schedules entity)
    {
        var sql = "INSERT INTO Schedules(startTimeSchedule, endTimeSchedule, daySchedule) VALUES (@startTimeSchedule, @endTimeSchedule, @daySchedule)";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, entity);
            return entity;
        }
    }

    public async Task UpdateAsync(Schedules entity)
    {
        var sql = "UPDATE Schedules SET startTimeSchedule = @startTimeSchedule, endTimeSchedule = @endTimeSchedule, daySchedule = @daySchedule WHERE idSchedule = @idSchedule";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, entity);
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Schedules WHERE idSchedule = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
    }
}