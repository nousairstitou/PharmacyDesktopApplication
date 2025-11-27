using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels {

    public sealed record InventoryViewModel {

        public int InventoryId { get; init; }
        public string InventoryName { get; init; } = string.Empty;
        public string Location { get; init; } = string.Empty;
        public int Capacity { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}