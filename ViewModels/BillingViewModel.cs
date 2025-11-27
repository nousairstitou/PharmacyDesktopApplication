using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels {

    public sealed record BillingViewModel {

        public int BillingId { get; init; }
        public decimal AmountPaid { get; init; }
        public string MethodName { get; init; } = null!;
        public DateTime BillingDate { get; init; }
        public string UserName { get; init; } = null!;
        public string BillingStatus { get; init; } = null!;
        public string? Note { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}