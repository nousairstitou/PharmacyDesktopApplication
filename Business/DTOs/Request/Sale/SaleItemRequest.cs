using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs.Request.Sale {

    [Serializable]
    public sealed record SaleItemRequest {

        [Required]
        public int MedicineId { get; init; }

        [Required]
        public int Quantity { get; init; }

        [Required]
        public decimal UnitPrice { get; init; }
    }
}