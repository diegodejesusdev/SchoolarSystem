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
        var sql = "SELECT cl.*, scl.*, sl.*, sf.*, sj.*, th.*, sh.* FROM Class cl " +
                  "JOIN SchoolarLevels scl ON cl.idSchoolarLevelC = scl.idSchoolarLevel " +
                  "JOIN SubLevels sl ON scl.idSublevelSL = sl.idSublevel " +
                  "JOIN SubjectFull sf ON cl.idSubjectFullC = sf.idSubjectFull " +
                  "JOIN Subjects sj ON sf.idSubjectSf = sj.idSubject " +
                  "JOIN Teachers th ON sf.idTeacherSf = th.idTeacher " +
                  "JOIN Schedules sh ON sf.idScheduleSf = sh.idSchedule";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = 
                await connection.QueryAsync<Class, SchoolarLevels, SubLevels, SubjectFull, Subjects, Teachers, Schedules, Class>(sql, 
                        (clss, schoolarLevel, sublevel, subjectFull, subject, teacher, schedules) =>
                        {
                            clss.SchoolarLevels = schoolarLevel;
                            clss.SchoolarLevels.SubLevels = sublevel;
                            clss.SubjectFull = subjectFull;
                            clss.SubjectFull.Subjects = subject;
                            clss.SubjectFull.Teachers = teacher;
                            clss.SubjectFull.Schedules = schedules;
                            return clss;
                        }, 
                        splitOn: "idSchoolarLevel, idSublevel, idSubjectFull, idSubject, idTeacher, idSchedule");
            return result;
        }
    }

    public async Task<Class> GetByIdAsync(int id)
    {
        var sql = "SELECT cl.*, scl.*, sl.*, sf.*, sj.*, th.*, sh.* FROM Class cl " +
                  "JOIN SchoolarLevels scl ON cl.idSchoolarLevelC = scl.idSchoolarLevel " +
                  "JOIN SubLevels sl ON scl.idSublevelSL = sl.idSublevel " +
                  "JOIN SubjectFull sf ON cl.idSubjectFullC = sf.idSubjectFull " +
                  "JOIN Subjects sj ON sf.idSubjectSf = sj.idSubject " +
                  "JOIN Teachers th ON sf.idTeacherSf = th.idTeacher " +
                  "JOIN Schedules sh ON sf.idScheduleSf = sh.idSchedule " +
                  "WHERE idClass = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = 
                await connection.QueryAsync<Class, SchoolarLevels, SubLevels, SubjectFull, Subjects, Teachers, Schedules, Class>(sql, 
                    (clss, schoolarLevel, sublevel, subjectFull, subject, teacher, schedules) =>
                    {
                        clss.SchoolarLevels = schoolarLevel;
                        clss.SchoolarLevels.SubLevels = sublevel;
                        clss.SubjectFull = subjectFull;
                        clss.SubjectFull.Subjects = subject;
                        clss.SubjectFull.Teachers = teacher;
                        clss.SubjectFull.Schedules = schedules;
                        return clss;
                    }, new {Id = id},
                    splitOn: "idSchoolarLevel, idSublevel, idSubjectFull, idSubject, idTeacher, idSchedule");
            return result.FirstOrDefault();
        }
    }

    public async Task<Class> AddAsync(Class entity)
    {
        var sql = "INSERT INTO Class(classroomClass, idSchoolarLevelC, idSubjectFullC) " +
                  "VALUES (@classroomClass, @idSchoolarLevelC, @idSubjectFullC)";

        var parameters = new
        {
            entity.classroomClass,
            entity.idSchoolarLevelC,
            entity.idSubjectFullC
        };
        
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, parameters);
            return entity;
        }
    }

    public async Task UpdateAsync(Class entity)
    {
        var sql = "UPDATE Class SET classroomClass = @classroomClass, idSchoolarLevelC = @idSchoolarLevelC, " +
                  "idSubjectFullC = @idSubjectFullC WHERE idClass = @idClass;";

        var parameters = new
        {
            entity.classroomClass,
            entity.idSchoolarLevelC,
            entity.idSubjectFullC,
            entity.idClass
        };
        
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, parameters);
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

