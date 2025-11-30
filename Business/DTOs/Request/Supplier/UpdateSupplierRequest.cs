using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Supplier {

    [Serializable]
    public sealed record UpdateSupplierRequest {

        public int? SupplierId { get; init; }

        [Required(ErrorMessage = "SupplierName is required")]
        [MaxLength(100, ErrorMessage = "SupplierName cannot exceed 100 characters")]
        public string SupplierName { get; init; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(15, ErrorMessage = "Phone cannot exceed 15 characters")]
        public string SupplierPhone { get; init; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string SupplierEmail { get; init; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(30, ErrorMessage = "Address cannot exceed 30 characters")]
        public string Address { get; init; } = string.Empty;
    }
}