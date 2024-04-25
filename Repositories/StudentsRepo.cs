using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class StudentsRepo : IStudentsRepo
{
    private readonly string? _connectionString;
    public StudentsRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    
    public async Task<IEnumerable<Students>> GetAllASync()
    {
        var sql = "SELECT st.*, sl.*, su.* FROM Students st " +
                  "JOIN SchoolarLevels sl ON st.idSchoolarLevelS = sl.idSchoolarLevel " +
                  "JOIN SubLevels su ON sl.idSublevelSL = su.idSublevel"; 
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Students, SchoolarLevels, SubLevels, Students>(sql,
                (students, schoolarLevels, subLevels) =>
                {
                    students.SchoolarLevels = schoolarLevels;
                    students.SchoolarLevels.SubLevels = subLevels;
                    return students;
                }, splitOn: "idSchoolarLevel, idSublevel");
            return result;
        }
    }

    public async Task<Students> GetByIdAsync(int id)
    {
        var sql = "SELECT st.*, sl.*, su.* FROM Students st " +
                  "JOIN SchoolarLevels sl ON st.idSchoolarLevelS = sl.idSchoolarLevel " +
                  "JOIN SubLevels su ON sl.idSublevelSL = su.idSublevel WHERE idStudent = @Id"; 
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = 
                await connection.QueryAsync<Students, SchoolarLevels, SubLevels, Students>(sql,
                (students, schoolarLevels, subLevels) =>
                {
                    students.SchoolarLevels = schoolarLevels;
                    students.SchoolarLevels.SubLevels = subLevels;
                    return students;
                }, new {Id = id}, splitOn: "idSchoolarLevel, idSublevel");
            return result.FirstOrDefault();
        }
    }
    
    public async Task<int> AddAsync(Students entity)
    {
        var sql = "INSERT INTO Students(nameStudent, ccStudent, emailStudent, phoneStudent, idSchoolarLevelS) " +
                  "VALUES(@nameStudent, @ccStudent, @emailStudent, @phoneStudent, @idSchoolarLevelS)";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(Students entity)
    {
        var sql = "UPDATE Students SET nameStudent = @nameStudent, ccStudent = @ccStudent, " +
                  "emailStudent = @emailStudent, phoneStudent = @phoneStudent, idSchoolarLevelS = @idSchoolarLevelS " +
                  "WHERE idStudent = @idStudent";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Students WHERE idStudent = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
    }
}

