using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using DocumentsService.src.interfaces;
using DocumentsService.src.models;

namespace DocumentsService.src.data
{
    public class DataSeeder
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var repo = scope.ServiceProvider.GetRequiredService<IDocumentRepository>();

            // Faker en español
            var faker = new Faker("es");

            // Documentos semilla fijos usando IDs reales (usa los del workspace service)
            var fixedDocs = new List<Document>
            {
                new Document
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    WorkspaceId = Guid.Parse("d3a1d94c-1f3e-445f-8412-7209c7c2af1b"), // workspace 1                    
                    Title = "Informe de arquitectura",
                    ContentJson = "[{\"type\":\"text\",\"content\":\"Documento inicial del taller.\"}]",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Document
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    WorkspaceId = Guid.Parse("d3a1d94c-1f3e-445f-8412-7209c7c2af1a"), // workspace 2
                    Title = "Lista de recursos",
                    ContentJson = "[{\"type\":\"text\",\"content\":\"Listado inicial de recursos para estudio.\"}]",
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Document
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    WorkspaceId = Guid.Parse("d3a1d94c-1f3e-445f-8412-7209c7c2af1c"), // workspace 3
                    Title = "Plan de proyecto",
                    ContentJson = "[{\"type\":\"text\",\"content\":\"Plan base para el proyecto colaborativo.\"}]",
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1),
                    IsDeleted = false
                }
            };

            // Insertar documentos fijos
            foreach (var doc in fixedDocs)
                repo.SeedDocument(doc);

            // ====== SEMILLA ALEATORIA ======
            var workspaceIds = new[]
            {
                Guid.Parse("d3a1d94c-1f3e-445f-8412-7209c7c2af1b"),
                Guid.Parse("d3a1d94c-1f3e-445f-8412-7209c7c2af1a"),
                Guid.Parse("d3a1d94c-1f3e-445f-8412-7209c7c2af1c")
            };

            var userIds = new[]
            {
                Guid.Parse("a08799f8-746f-46b4-8134-2ef211fe705a"),
                Guid.Parse("9fd8ec52-3aa4-4097-86fa-2c576bc06e01"),
                Guid.Parse("2db519ca-4836-4e01-977f-ec518a081d54")
            };

            // 10 documentos aleatorios
            for (int i = 0; i < 10; i++)
            {
                var doc = new Document
                {
                    Id = Guid.NewGuid(),
                    WorkspaceId = faker.PickRandom(workspaceIds),
                    Title = faker.Lorem.Sentence(),
                    ContentJson = $"[{{\"type\":\"text\",\"content\":\"{faker.Lorem.Paragraph()}\"}}]",
                    CreatedAt = faker.Date.Past(),
                    UpdatedAt = faker.Date.Recent(),
                    IsDeleted = false
                };

                repo.SeedDocument(doc);
            }
        }
    }
}