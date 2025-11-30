using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Sale {

    [Serializable]
    public sealed record CreateSaleRequest {

        [MaxLength(255, ErrorMessage = "Note cannot exceed 255 characters")]
        public string? Note { get; init; }

        [Required(ErrorMessage = "Payment Method Id is required")]
        public int PaymentMethodId { get; init; }

        [Required(ErrorMessage = "Amount Paid is required")]
        public decimal AmountPaid { get; init; }

        [Required(ErrorMessage = "Created By is required")]
        public int CreatedBy { get; init; }

        [MaxLength(255, ErrorMessage = "Billing Note cannot exceed 255 characters")]
        public string? BillingNote { get; init; }

        public IReadOnlyCollection<SaleItemRequest> SaleItems { get; init; } = Array.Empty<SaleItemRequest>();
    }
}