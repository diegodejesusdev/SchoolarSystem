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
        var sql = "SELECT s.daySchedule, s.startTimeSchedule, s.endTimeSchedule FROM Schedules s";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Schedules>(sql);
            return result;
        }
    }

    public async Task<Schedules> GetByIdAsync(int id)
    {
        var sql = "SELECT s.daySchedule, s.startTimeSchedule, s.endTimeSchedule FROM Schedules s WHERE idSchedule = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Schedules>(sql, new { Id = id });
            return result;
        }
    }

    public async Task<int> AddAsync(Schedules entity)
    {
        var sql = "INSERT INTO Schedules(startTimeSchedule, endTimeSchedule, daySchedule) VALUES (@startTimeSchedule, @endTimeSchedule, @daySchedule)";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(Schedules entity)
    {
        var sql = "UPDATE Schedules SET startTimeSchedule = @startTimeSchedule, endTimeSchedule = @endTimeSchedule, daySchedule = @daySchedule";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
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