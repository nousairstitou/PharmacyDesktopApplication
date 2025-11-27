using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs.Request.Inventory {

    public sealed record UpdateInventoryRequest {

        public int? InventoryId { get; init; }

        [Required]
        [MaxLength(100)]
        public string InventoryName { get; init; } = null!;

        [Required]
        [MaxLength(255)]
        public string Location { get; init; } = null!;

        [Required]
        public int Capacity { get; init; }
    }
}