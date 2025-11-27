using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Inventory {

    public sealed record CreateInventoryRequest {

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