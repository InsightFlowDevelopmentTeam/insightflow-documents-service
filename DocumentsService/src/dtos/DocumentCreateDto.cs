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
    /// Este DTO se usará para crear un nuevo documento
    /// </summary>
    public class DocumentCreateDto
    {
        [Required] 
        public Guid WorkspaceId { get; set; }

        [Required] [MinLength(1)] 
        public string Title { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string ContentJson { get; set; } = "[]";
        public string? OwnerId { get; set; } = null;
    }
}