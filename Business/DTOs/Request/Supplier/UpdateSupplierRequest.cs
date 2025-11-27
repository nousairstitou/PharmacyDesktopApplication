using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Supplier {

    public sealed record UpdateSupplierRequest {

        public int? SupplierId { get; init; }

        [Required]
        [MinLength(100)]
        public string SupplierName { get; init; } = string.Empty;

        [Required]
        [MinLength(15)]
        public string SupplierPhone { get; init; } = string.Empty;

        [MinLength(100)]
        public string SupplierEmail { get; init; } = string.Empty;

        public int AddressId { get; init; }
    }
}