using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Customer {

    public sealed record UpdateCustomerRequest {

        public int CustomerId { get; init; }

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