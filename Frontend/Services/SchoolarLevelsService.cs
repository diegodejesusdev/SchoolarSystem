using System.Net;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Frontend.Models;

namespace Frontend.Services;

public class SchoolarLevelsService : ISchoolarLevelsService
{
    private readonly HttpClient HttpClient;

    public SchoolarLevelsService(HttpClient _httpClient)
    {
        HttpClient = _httpClient;
        ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
    }

    async Task<List<SchoolarLevels>> ISchoolarLevelsService.GetSchoolarLevels()
    {
        return await HttpClient.GetFromJsonAsync<List<SchoolarLevels>>("scholar/Schoolarlevels");
    }

    async Task<SchoolarLevels> ISchoolarLevelsService.GetShoolarLevel(int id)
    {
        return await HttpClient.GetFromJsonAsync<SchoolarLevels>($"scholar/Schoolarlevels/{id}");
    }

    async Task<SchoolarLevels> ISchoolarLevelsService.AddSchoolarLevel(SchoolarLevels schoolarLevel)
    {
        var result = await HttpClient.PostAsJsonAsync<SchoolarLevels>($"scholar/Schoolarlevels", schoolarLevel);
        var newLevel = await result.Content.ReadFromJsonAsync<SchoolarLevels>();
        return newLevel;
    }

    async Task ISchoolarLevelsService.UpdateSchoolarLevel(int id, SchoolarLevels schoolarLevel)
    {
        await HttpClient.PutAsJsonAsync<SchoolarLevels>($"scholar/Schoolarlevels?id={id}", schoolarLevel);
    }

    public async Task DeleteSchoolarLevel(int id)
    {
        Console.WriteLine(id);
        await HttpClient.DeleteAsync($"scholar/Schoolarlevels/{id}");
    }
}