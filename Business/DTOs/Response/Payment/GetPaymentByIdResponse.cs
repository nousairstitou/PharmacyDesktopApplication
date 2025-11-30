using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Payment {

    [Serializable]
    public sealed record GetPaymentByIdResponse {

        public int? PaymentId { get; init; } 
        public int SaleId { get; init; }
        public int PaymentMethodId { get; init; }
        public DateTime PaymentDate { get; init; }
        public decimal AmountPaid { get; init; }
        public int PaymentStatus { get; init; }
    }
}