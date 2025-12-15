using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DocumentsService.src.interfaces;
using DocumentsService.src.repositories;

var builder = WebApplication.CreateBuilder(args);

// Anadir servicios y controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorio en memoria
builder.Services.AddSingleton<IDocumentRepository, DocumentRepository>();

// Configura CORS para permitir solicitudes desde cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("AllowAll");

// Ejecutar DataSeeder al iniciar el servicio
using (var scope = app.Services.CreateScope())
{
    var seeder = DocumentsService.src.data.DataSeeder.InitializeAsync(scope.ServiceProvider);
    seeder.Wait();
}


app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();
app.MapControllers();

app.Run();
