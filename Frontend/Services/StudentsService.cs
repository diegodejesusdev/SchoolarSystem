using System.Net;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Frontend.Models;

namespace Frontend.Services;

public class StudentsService : IStudentsService
{
    private readonly HttpClient HttpClient;

    public StudentsService(HttpClient _httpClient)
    {
        HttpClient = _httpClient;
        ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
    }

    async Task<List<Students>> IStudentsService.GetStudents()
    {
        return await HttpClient.GetFromJsonAsync<List<Students>>("schoolar/Students");
    }

    async Task<Students> IStudentsService.GetStudent(int id)
    {
        return await HttpClient.GetFromJsonAsync<Students>($"schoolar/Students/{id}");
    }

    async Task<Students> IStudentsService.AddStudent(Students students)
    {
        var result = await HttpClient.PostAsJsonAsync<Students>($"schoolar/Students", students);
        var newStudent = await result.Content.ReadFromJsonAsync<Students>();
        return newStudent;
    }

    async Task IStudentsService.UpdateStudent(int id, Students students)
    {
        await HttpClient.PutAsJsonAsync<Students>($"schoolar/Students?id={id}", students);
    }

    public async Task DeleteStudent(int id)
    {
        Console.WriteLine(id);
        await HttpClient.DeleteAsync($"schoolar/Students/{id}");
    }
}