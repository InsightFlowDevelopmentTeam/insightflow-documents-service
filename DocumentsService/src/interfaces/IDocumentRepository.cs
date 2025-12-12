using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsService.src.models;

namespace DocumentsService.src.interfaces
{
    /// <summary>
    /// IDocumentRepository
    /// </summary> <summary>
    /// Interfaz que declara los metodos para el repositorio de documentos
    /// </summary>
    public interface IDocumentRepository
    {
         Task<Document> CreateAsync(Document doc);
        Task<Document?> GetByIdAsync(Guid id);
        Task<IEnumerable<Document>> GetByWorkspaceAsync(Guid workspaceId);
        Task<Document?> UpdateContentAsync(Guid id, string contentJson);
        Task<bool> SoftDeleteAsync(Guid id);
        void SeedDocument(Document doc);
    }
}