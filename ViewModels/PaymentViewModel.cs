using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels {

    public sealed record PaymentViewModel {

        public int PaymentId { get; init; }
        public DateTime PaymentDate { get; init; }
        public decimal AmountPaid { get; init; }
        public string MethodName { get; init; } = null!;
        public string PaymentStatus { get; init; } = null!;
        public DateTime CreatedAt { get; init; }
    }
}