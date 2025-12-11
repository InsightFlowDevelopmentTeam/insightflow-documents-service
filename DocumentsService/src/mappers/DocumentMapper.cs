using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsService.src.dtos;
using DocumentsService.src.models;

namespace DocumentsService.src.mappers
{
    /// <summary>
    /// Mapper para convertir documentos entre distintas capas
    /// </summary> <summary>
    /// 
    /// </summary>
    public static class DocumentMapper
    {
        public static DocumentDto? ToDto(this Document doc)
        {
            if (doc == null) return null;
            return new DocumentDto
            {
                Id = doc.Id,
                WorkspaceId = doc.WorkspaceId,
                Title = doc.Title,
                Icon = doc.Icon,
                ContentJson = doc.ContentJson,
                IsDeleted = doc.IsDeleted,
                CreatedAt = doc.CreatedAt,
                UpdatedAt = doc.UpdatedAt
            };
        }

        public static Document FromCreateDto(this DocumentCreateDto dto)
        {
            return new Document
            {
                WorkspaceId = dto.WorkspaceId,
                Title = dto.Title,
                Icon = dto.Icon,
                ContentJson = string.IsNullOrWhiteSpace(dto.ContentJson) ? "[]" : dto.ContentJson,
                OwnerId = dto.OwnerId
            };
        }

        public static void MapUpdates(this Document doc, DocumentUpdateDto dto)
        {
            if (!string.IsNullOrEmpty(dto.Title)) doc.Title = dto.Title;
            if (!string.IsNullOrEmpty(dto.Icon)) doc.Icon = dto.Icon;
            if (!string.IsNullOrEmpty(dto.ContentJson)) doc.ContentJson = dto.ContentJson;
            doc.UpdatedAt = DateTime.UtcNow;
        }
    }
}