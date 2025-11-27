using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs.Request.Customer {

    public sealed record CreateCustomerRequest {

        [Required]
        [MaxLength(100)]
        public string Name { get; init; } = null!;

        [Required]
        [MaxLength(15)]
        public string Phone { get; init; } = null!;

        [MaxLength(100)]
        public string? Email { get; init; }
        public int? AddressId { get; init; }
    }
}