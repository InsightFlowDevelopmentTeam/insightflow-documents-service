using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsService.src.interfaces;
using DocumentsService.src.models;

namespace DocumentsService.src.repositories
{
    /// <summary>
    /// Repositorio que implementa los metodos declarados de la interfaz de documentos
    /// </summary>
    public class DocumentRepository : IDocumentRepository
    {
         // Un ConcurrentDictionary para seguridad en caso de acceso concurrente
        private readonly ConcurrentDictionary<Guid, Document> _store = new();

        public Task<Document> CreateAsync(Document doc)
        {
            doc.Id = Guid.NewGuid(); // Identificador UUID v4
            doc.CreatedAt = DateTime.UtcNow;
            _store[doc.Id] = doc;
            return Task.FromResult(doc);
        }

        public Task<Document?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var doc);
            return Task.FromResult(doc);
        }

        public Task<IEnumerable<Document>> GetByWorkspaceAsync(Guid workspaceId)
        {
            var list = _store.Values
                .Where(d => d.WorkspaceId == workspaceId && !d.IsDeleted)
                .OrderByDescending(d => d.UpdatedAt ?? d.CreatedAt)
                .AsEnumerable();
            return Task.FromResult(list);
        }

        public Task<Document?> UpdateContentAsync(Guid id, string contentJson)
        {
            if (!_store.TryGetValue(id, out var doc) || doc.IsDeleted)
            {
                return Task.FromResult<Document?>(null);
            }

            // Asegúrate que la clase Document tenga la propiedad ContentJson
            doc.ContentJson = contentJson;
            doc.UpdatedAt = DateTime.UtcNow;
            _store[id] = doc;
            return Task.FromResult<Document?>(doc);
        }

        public Task<bool> SoftDeleteAsync(Guid id)
        {
            if (!_store.TryGetValue(id, out var doc) || doc.IsDeleted) return Task.FromResult(false);
            doc.IsDeleted = true;
            doc.DeletedAt = DateTime.UtcNow;
            _store[id] = doc;
            return Task.FromResult(true);
        }

        public void SeedDocument(Document doc)
        {
             // Si existe, sobreescribir
            if (doc.Id == Guid.Empty) doc.Id = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(doc.ContentJson)) doc.ContentJson = "[]";
            _store[doc.Id] = doc;
        }
    }
}