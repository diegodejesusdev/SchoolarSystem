using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class NotesRepo : INotesRepo
{
    private readonly string? _connectionString;
    public NotesRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    
    public async Task<IEnumerable<Notes>> GetAllASync()
    {
        var sql = "SELECT nt.*, st.*, sc.*, sl.*, sf.*, th.*, sj.* FROM Notes nt " +
                  "JOIN Students st ON nt.idStudentN = st.idStudent " +
                  "JOIN SchoolarLevels sc ON st.idSchoolarLevelS = sc.idSchoolarLevel " +
                  "JOIN SubLevels sl ON sc.idSublevelSL = sl.idSublevel " +
                  "JOIN SubjectFull sf ON nt.idSubjectFullN = sf.idSubjectFull " +
                  "JOIN Teachers th ON sf.idTeacherSf = th.idTeacher " +
                  "JOIN Subjects sj ON sf.idSubjectSf = sj.idSubject";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result =
                await connection
                    .QueryAsync<Notes, Students, SchoolarLevels, SubLevels, SubjectFull, Subjects, Teachers, Notes>(sql,
                        (notes, students, schoolarlevel, sublevel, subjectfull, subject, teacher) =>
                        {
                            notes.Students = students;
                            notes.SubjectFull = subjectfull;
                            notes.Students.SchoolarLevels = schoolarlevel;
                            notes.Students.SchoolarLevels.SubLevels = sublevel;
                            notes.SubjectFull.Subjects = subject;
                            notes.SubjectFull.Teachers = teacher;
                            return notes;
                        }, splitOn:"idStudent, idSchoolarLevel, idSublevel, idSubjectFull, idSubject, idTeacher");
                        return result;
        }
    }

    public async Task<Notes> GetByIdAsync(int id)
    {
        var sql = "SELECT nt.*, st.*, sc.*, sl.*, sf.*, th.*, sj.* FROM Notes nt " +
                  "JOIN Students st ON nt.idStudentN = st.idStudent " +
                  "JOIN SchoolarLevels sc ON st.idSchoolarLevelS = sc.idSchoolarLevel " +
                  "JOIN SubLevels sl ON sc.idSublevelSL = sl.idSublevel " +
                  "JOIN SubjectFull sf ON nt.idSubjectFullN = sf.idSubjectFull " +
                  "JOIN Teachers th ON sf.idTeacherSf = th.idTeacher " +
                  "JOIN Subjects sj ON sf.idSubjectSf = sj.idSubject " +
                  "WHERE idNote = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result =
                await connection
                    .QueryAsync<Notes, Students, SchoolarLevels, SubLevels, SubjectFull, Subjects, Teachers, Notes>(sql,
                        (notes, students, schoolarlevel, sublevel, subjectfull, subject, teacher) =>
                        {
                            notes.Students = students;
                            notes.SubjectFull = subjectfull;
                            notes.Students.SchoolarLevels = schoolarlevel;
                            notes.Students.SchoolarLevels.SubLevels = sublevel;
                            notes.SubjectFull.Subjects = subject;
                            notes.SubjectFull.Teachers = teacher;
                            return notes;
                        }, new {Id = id}, splitOn:"idStudent, idSchoolarLevel, idSublevel, idSubjectFull, idSubject, idTeacher");
            return result.FirstOrDefault();
        }
    }

    public async Task<int> AddAsync(Notes entity)
    {
        var sql = "INSERT INTO Notes(noteN, idStudentN, idSubjectFullN) VALUES (@noteN, @idStudentN, @idSubjectFullN)";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(Notes entity)
    {
        var sql = "UPDATE Notes SET noteN = @noteN, idStudentN = @idStudentN, idSubjectFullN = @idSubjectFullN WHERE idNote = @idNote;";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Notes WHERE idNote = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new {Id = id});
            return result;
        }
    }
}

