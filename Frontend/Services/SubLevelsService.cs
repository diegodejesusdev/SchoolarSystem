using System.Net;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Frontend.Models;

namespace Frontend.Services;

public class SubLevelsService : ISubLevelsService
{
    private readonly HttpClient HttpClient;

    public SubLevelsService(HttpClient _httpClient)
    {
        HttpClient = _httpClient;
        ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
    }
    
    async Task<List<SubLevels>> ISubLevelsService.GetSubLevels()
    {
        return await HttpClient.GetFromJsonAsync<List<SubLevels>>("schoolar/Sublevels");
    }
}