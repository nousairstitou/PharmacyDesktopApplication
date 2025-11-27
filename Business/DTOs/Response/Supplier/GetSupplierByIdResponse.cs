using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Supplier {
    
    public sealed record GetSupplierByIdResponse {

        public int? SupplierId { get; init; }
        public string SupplierName { get; init; } = string.Empty;
        public string SupplierPhone { get; init; } = string.Empty;
        public string? SupplierEmail { get; init; }
        public int? AddressId { get; init; }
    }
}