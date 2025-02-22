using Microsoft.EntityFrameworkCore;
using api_psp.Models;  // Asegúrate de usar el namespace correcto

var builder = WebApplication.CreateBuilder(args);

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
