using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsService.src.dtos
{
    /// <summary>
    /// DocumentoUpdateDto
    /// </summary> <summary>
    /// Este DTO se usará para actualizar contenido del documento existente
    /// </summary>
    public class DocumentUpdateDto
    {
        [Required]
        public string? ContentJson { get; set; }
        // opcional: título / icono si quieres permitir editar metadatos
        public string? Title { get; set; }
        public string? Icon { get; set; }
    }
}