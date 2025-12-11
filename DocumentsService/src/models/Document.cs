using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsService.src.models
{
    public class Document
    {
        public Guid Id { get; set; }
        public Guid WorkspaceId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string ContentJson { get; set; } = "[]"; // <-- debe existir
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? OwnerId { get; set; }
    }
}