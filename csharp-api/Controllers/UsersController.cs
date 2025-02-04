using System.Threading.Tasks;
using csharp_api.Models;
using csharp_api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace csharp_api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly ApiService _apiService;
    private readonly string phpApiUrl = "http://php-api/index.php";

    public UsersController(ApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        string response = await _apiService.GetDataFromApi(phpApiUrl);
        if (!ApiService.IsJsonValid(response))
        {
            return Problem("❌ Error: La respuesta de php-api no es JSON válido.");
        }

        var users = JsonConvert.DeserializeObject<User[]>(response);
        return Ok(users);
    }
}
