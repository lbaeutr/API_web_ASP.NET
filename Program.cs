using Microsoft.EntityFrameworkCore;
using api_psp.Models; 
using api_psp.Services;
using api_psp.Settings;

var builder = WebApplication.CreateBuilder(args);

// Configuracion MongoDB 
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<JugadorService>(); // Inyectamos el servicio
// Registra el servicio de controladores
builder.Services.AddControllers();


// Registra el DbContext usando la base de datos en memoria
builder.Services.AddDbContext<JugadorContext>(opt =>
    opt.UseInMemoryDatabase("JugadoresDB"));

// Registra Swagger para documentación y pruebas
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
