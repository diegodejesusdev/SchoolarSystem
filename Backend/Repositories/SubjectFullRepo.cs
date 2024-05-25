using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class SubjectFullRepo : ISubjectFullRepo
{
    private readonly string? _connectionString;
    public SubjectFullRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    
    public async Task<IEnumerable<SubjectFull>> GetAllASync()
    {
        var sql = "SELECT * FROM SubjectFull sf " +
                  "JOIN Schedules sc ON sf.idScheduleSf = sc.idSchedule " +
                  "JOIN Subjects sj ON sf.idSubjectSf = sj.idSubject " +
                  "JOIN Teachers th ON sf.idTeacherSf = th.idTeacher";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = 
                await connection
                    .QueryAsync<SubjectFull, Schedules, Subjects, Teachers, SubjectFull>(sql,
                        (fullSubject, schedules, subjects, teachers) =>
                        {
                            fullSubject.Schedules = schedules;
                            fullSubject.Subjects = subjects;
                            fullSubject.Teachers = teachers;
                            return fullSubject;
                        }, splitOn: "idSchedule, idSubject, idTeacher");
                        return result;
        }
    }

    public async Task<SubjectFull> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM SubjectFull sf " +
                  "JOIN Schedules sc ON sf.idScheduleSf = sc.idSchedule " +
                  "JOIN Subjects sj ON sf.idSubjectSf = sj.idSubject " +
                  "JOIN Teachers th ON sf.idTeacherSf = th.idTeacher " +
                  "WHERE idSubjectFull = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = 
                await connection
                    .QueryAsync<SubjectFull, Schedules, Subjects, Teachers, SubjectFull>(sql,
                        (fullSubject, schedules, subjects, teachers) =>
                        {
                            fullSubject.Schedules = schedules;
                            fullSubject.Subjects = subjects;
                            fullSubject.Teachers = teachers;
                            return fullSubject;
                        }, new {Id = id}, 
                        splitOn: "idSchedule, idSubject, idTeacher");
            return result.FirstOrDefault();
        }
    }

    public async Task<SubjectFull> AddAsync(SubjectFull entity)
    {
        var sql = "INSERT INTO SubjectFull(yearSf, idScheduleSf, idSubjectSf, idTeacherSf) " +
                  "VALUES (@yearSf, @idScheduleSf, @idSubjectSf, @idTeacherSf)";

        var parameters = new
        {
            entity.yearSf,
            entity.idScheduleSf,
            entity.idSubjectSf,
            entity.idTeacherSf
        };
        
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, parameters);
            return entity;
        }
    }

    public async Task UpdateAsync(SubjectFull entity)
    {
        var sql = "UPDATE SubjectFull SET yearSf = @yearSf, idScheduleSf = @idScheduleSf, " +
                  "idSubjectSf = @idSubjectSf, idTeacherSf = @idTeacherSf WHERE idSubjectFull = @idSubjectFull";
        
        var parameters = new
        {
            entity.yearSf,
            entity.idScheduleSf,
            entity.idSubjectSf,
            entity.idTeacherSf,
            entity.idSubjectFull
        };
        
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, parameters);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM SubjectFull WHERE idSubjectFull = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, new {Id = id});
        }
    }
}

