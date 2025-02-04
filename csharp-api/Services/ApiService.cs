using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace csharp_api.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDataFromApi(string url)
    {
        try
        {
            return await _httpClient.GetStringAsync(url);
        }
        catch (Exception ex)
        {
            return $"❌ Error de conexión: {ex.Message}";
        }
    }

    public static bool IsJsonValid(string str)
    {
        try
        {
            var obj = JsonConvert.DeserializeObject<object>(str);
            return obj != null;
        }
        catch
        {
            return false;
        }
    }
}
