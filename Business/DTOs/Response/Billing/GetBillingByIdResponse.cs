using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Billing {

    [Serializable]
    public sealed record GetBillingByIdResponse {

        public int? BillingId { get; init; }
        public DateTime BillingDate { get; init; }
        public int CreatedBy { get; init; }
        public string? Note { get; init; }
        public int PaymentId { get; init; }
        public byte status { get; init; }
    }
}