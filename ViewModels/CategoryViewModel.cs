using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels {

    public sealed record CategoryViewModel {

        public int CategoryId { get; init; }
        public string CategoryName { get; init; } = string.Empty;
        public string IsActive { get; init; } = string.Empty;
        public DateTime IsDeactivatedAt { get; init; }
        public DateTime CreatedDate { get; init; }
        public string CreatedBy { get; init; } = string.Empty;
        public string? Description { get; init; }
    }
}