using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs.Request.Supplier {

    public sealed record CreateSupplierRequest {

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