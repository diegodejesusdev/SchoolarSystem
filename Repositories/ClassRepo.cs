using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class ClassRepo : IClassRepo
{
    private readonly string? _connectionString;
    public ClassRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    
    public async Task<IEnumerable<Class>> GetAllASync()
    {
        var sql = "SELECT cl.*, sl.*, scl.*, sf.*, sj.*, th.*, sh.*" +
                  "FROM Class cl " +
                  "JOIN SubLevels sl ON cl.idSublevelC = sl.idSublevel " +
                  "JOIN SchoolarLevels scl ON sl.idSchLevelS = scl.idSchoolarLevel " +
                  "JOIN SubjectFull sf ON cl.idSubjectFullC = sf.idSubjectFull " +
                  "JOIN Subjects sj ON sf.idSubjectSf = sj.idSubject " +
                  "JOIN Teachers th ON sf.idTeacherSf = th.idTeacher " +
                  "JOIN Schedules sh ON sf.idScheduleSf = sh.idSchedule";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Class, SubLevels, SchoolarLevels, SubjectFull, Subjects, Teachers, Schedules, Class>(sql,
                        (clss, sublevel, schoolarLevel, subjectFull, subject, teacher, schedules) =>
                        {
                            clss.SubLevels = sublevel;
                            clss.SubLevels.SchoolarLevels = schoolarLevel;
                            clss.SubjectFull = subjectFull;
                            clss.SubjectFull.Subjects = subject;
                            clss.SubjectFull.Teachers = teacher;
                            clss.SubjectFull.Schedules = schedules;
                            return clss;
                        }, splitOn: "idSublevel, idSchoolarLevel, idSubjectFull, idSubject, idTeacher, idSchedule");
            return result;
        }
    }

    public async Task<Class> GetByIdAsync(int id)
    {
        var sql = "SELECT cl.*, sl.*, scl.*, sf.*, sj.*, th.*, sh.* " +
                  "FROM Class cl " +
                  "JOIN SubLevels sl ON cl.idSublevelC = sl.idSublevel " +
                  "JOIN SchoolarLevels scl ON sl.idSchLevelS = scl.idSchoolarLevel " +
                  "JOIN SubjectFull sf ON cl.idSubjectFullC = sf.idSubjectFull " +
                  "JOIN Subjects sj ON sf.idSubjectSf = sj.idSubject " +
                  "JOIN Teachers th ON sf.idTeacherSf = th.idTeacher " +
                  "JOIN Schedules sh ON sf.idScheduleSf = sh.idSchedule " +
                  "WHERE cl.idClass = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Class, SubLevels, SchoolarLevels, SubjectFull, Subjects, Teachers, Schedules, Class>(sql,
                (clss, sublevel, schoolarLevel, subjectFull, subject, teacher, schedules) =>
                {
                    clss.SubLevels = sublevel;
                    clss.SubLevels.SchoolarLevels = schoolarLevel;
                    clss.SubjectFull = subjectFull;
                    clss.SubjectFull.Subjects = subject;
                    clss.SubjectFull.Teachers = teacher;
                    clss.SubjectFull.Schedules = schedules;
                    return clss;
                }, new {Id = id},splitOn: "idSublevel, idSchoolarLevel, idSubjectFull, idSubject, idTeacher, idSchedule");
            return result.FirstOrDefault();
        }
    }

    public async Task<int> AddAsync(Class entity)
    {
        var sql = "INSERT INTO Class(classroomClass, idSublevelC, idSubjectFullC) VALUES (@classroomClass, @idSublevelC, @idSubjectFullC)";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(Class entity)
    {
        var sql = "UPDATE Class SET classroomClass = @classroomClass, idSublevelC = @idSublevelC, idSubjectFullC = @idSubjectFullC;";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Class WHERE idClass = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new {Id = id});
            return result;
        }
    }
}

