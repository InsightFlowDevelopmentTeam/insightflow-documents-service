using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsService.src.dtos
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public Guid WorkspaceId { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? ContentJson { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}