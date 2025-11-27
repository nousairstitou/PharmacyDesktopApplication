using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels {

    public sealed record SaleViewModel {

        public int SaleId { get; init; }
        public string Name { get; init; } = null!; 
        public DateTime SaleDate { get; init; }
        public decimal TotalAmount { get; init; }
        public string SaleStatus { get; init; } = null!;
        public string? Note { get; init; };
        public DateOnly CreatedDate { get; init; }
    }
}