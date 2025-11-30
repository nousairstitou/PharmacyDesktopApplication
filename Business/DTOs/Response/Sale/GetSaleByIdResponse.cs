using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Sale {

    [Serializable]
    public sealed record GetSaleByIdResponse {

        public int? SaleId { get; init; }
        public int CustomerId { get; init; }
        public DateTime SaleDate { get; init; }
        public string? Note { get; init; }
        public byte Status { get; init; }
        public decimal TotalAmount { get; init; }
    }
}