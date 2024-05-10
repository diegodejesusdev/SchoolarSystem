using Dapper;
using Microsoft.Data.Sqlite;
using ApiSysSchoolar.Models;
using ApiSysSchoolar.Repositories.Application;

namespace ApiSysSchoolar.Repositories;

public class SubjectsRepo : ISubjectsRepo
{
    private readonly string? _connectionString;
    public SubjectsRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Sqlite");
    }
    public async Task<IEnumerable<Subjects>> GetAllASync()
    {
        var sql = "SELECT * FROM Subjects";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.QueryAsync<Subjects>(sql);
            return result;
        }
    }

    public async Task<Subjects> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Subjects WHERE idSubject = @Id";
        using (var conneciton = new SqliteConnection(_connectionString))
        {
            conneciton.Open();
            var result = await conneciton.QuerySingleOrDefaultAsync<Subjects>(sql, new { Id = id });
            return result;
        }
    }

    public async Task<int> AddAsync(Subjects entity)
    {
        var sql = "INSERT INTO Subjects(nameSubject, infoSubject) VALUES (@nameSubject, @infoSubject);";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(Subjects entity)
    {
        var sql = "UPDATE Subjects SET nameSubject = @nameSubject, infoSubject = @infoSubject WHERE idSubject = @idSubject";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Subjects WHERE idSubject = @Id";
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
    }
}

