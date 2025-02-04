using csharp_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios
builder.Services.AddHttpClient<ApiService>();
builder.Services.AddControllers();

var app = builder.Build();

// Mapear controladores
app.MapControllers();

app.Run();
