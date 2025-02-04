using System.Threading.Tasks;
using csharp_api.Models;
using csharp_api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace csharp_api.Controllers;

[ApiController]
[Route("transactions")]
public class TransactionsController : ControllerBase
{
    private readonly ApiService _apiService;
    private readonly string nodeApiUrl = "http://node-api:3000/transactions/user/";

    public TransactionsController(ApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetTransactions(int id)
    {
        string response = await _apiService.GetDataFromApi($"{nodeApiUrl}{id}");

        if (!ApiService.IsJsonValid(response))
        {
            return Problem($"❌ Error: La respuesta de node-api para usuario {id} no es JSON válido.");
        }

        var transactions = JsonConvert.DeserializeObject<Transaction[]>(response);
        return Ok(transactions);
    }
}
