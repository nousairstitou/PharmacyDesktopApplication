using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Inventory {

    [Serializable]
    public sealed record CreateInventoryRequest {

        [Required(ErrorMessage = "InventoryName is required")]
        [MaxLength(100, ErrorMessage = "InventoryName cannot exceed 100 characters")]
        public string InventoryName { get; init; } = null!;

        [Required(ErrorMessage = "Location is required")]
        [MaxLength(255, ErrorMessage = "Location cannot exceed 255 characters")]
        public string Location { get; init; }

        [Required]
        public int Capacity { get; init; }
    }
}