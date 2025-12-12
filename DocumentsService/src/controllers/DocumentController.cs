using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentsService.src.dtos;
using DocumentsService.src.interfaces;
using DocumentsService.src.mappers;
using Microsoft.AspNetCore.Mvc;

namespace DocumentsService.src.controllers
{
    /// <summary>
    /// Controlador de endpoits de documentos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _repo;
        public DocumentController(IDocumentRepository repo)
        {
            _repo = repo;
        }

        // Crear documento nuevo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var model = dto.FromCreateDto();
            var created = await _repo.CreateAsync(model);
            var result = created.ToDto();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // Obtener documento por id (visualizar contenido)
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var doc = await _repo.GetByIdAsync(id);
            if (doc == null || doc.IsDeleted) return NotFound();            
            return Ok(doc.ToDto());
        }

        // Obtener documentos por workspace
        [HttpGet("workspace/{workspaceId:guid}")]
        public async Task<IActionResult> GetByWorkspace(Guid workspaceId)
        {
            var docs = await _repo.GetByWorkspaceAsync(workspaceId);
            return Ok(docs.Select(d => d.ToDto()));
        }

        // Actualizar contenido de documento existente
        [HttpPut("{id:guid}/content")]
        public async Task<IActionResult> UpdateContent(Guid id, [FromBody] DocumentUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // Opcional: validar permisos del editor
            var updated = await _repo.UpdateContentAsync(id, dto.ContentJson ?? "[]");
            if (updated == null) return NotFound();
            return Ok(updated.ToDto());
        }

        // Soft delete (desactivar documento)
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var ok = await _repo.SoftDeleteAsync(id);
            if (!ok) return NotFound();
            return Ok(new { message = "Document moved to trash (soft deleted)." });
        }
    }
}