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
        var sql = "SELECT st.nameStudent, st.ccStudent, st.emailStudent, st.phoneStudent, sc.nameLevel, sl.nameSublevel, sl.yearSublevel " +
                  "FROM Students st JOIN SubLevels sl ON st.idSublevelS = sl.idSublevel JOIN SchoolarLevels sc ON sl.idSchLevelS = sc.idSchoolarLevel";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Students, SubLevels, SchoolarLevels, Students>(sql,
                (students, subLevels, schoolarLevels) =>
                {
                    students.SubLevels = subLevels;
                    students.SubLevels.SchoolarLevels = schoolarLevels;
                    return students;
                }, splitOn: "idSublevel, idSchoolarLevel");
            return result;
        }
    }

    public async Task<Students> GetByIdAsync(int id)
    {
        var sql = "SELECT st.nameStudent, st.ccStudent, st.emailStudent, st.phoneStudent, sc.nameLevel, sl.nameSublevel, sl.yearSublevel " +
                  "FROM Students st JOIN SubLevels sl ON st.idSublevelS = sl.idSublevel " +
                  "JOIN SchoolarLevels sc ON sl.idSchLevelS = sc.idSchoolarLevel WHERE idStudent = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Students, SubLevels, SchoolarLevels, Students>(sql,
                (students, subLevels, schoolarLevels) =>
                {
                    students.SubLevels = subLevels;
                    students.SubLevels.SchoolarLevels = schoolarLevels;
                    return students;
                }, new {Id = id}, splitOn: "idSublevel, idSchoolarLevel");
            return result.FirstOrDefault();
        }
    }
    
    public async Task<int> AddAsync(Students entity)
    {
        var sql = "INSERT INTO Students(nameStudent, ccStudent, emailStudent, phoneStudent, idSublevelS) " +
                  "VALUES(@nameStudent, @ccStudent, @emailStudent, @phoneStudent, @idSublevelS)";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(Students entity)
    {
        var sql = "UPDATE Students SET nameStudent = @nameStudent, ccStudent = @ccStudent, emailStudent = @emailStudent, " +
                  "phoneStudent = @phoneStudent, idSublevelS = @idSublevelS";
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

