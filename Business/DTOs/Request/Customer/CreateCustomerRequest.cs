using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs.Request.Customer {

    [Serializable]
    public sealed record CreateCustomerRequest {

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; init; } = null!;

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(15, ErrorMessage = "Phone cannot exceed 15 characters")]
        public string Phone { get; init; } = null!;

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string? Email { get; init; }

        public int? AddressId { get; init; }
    }
}