using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class TransactionSale {

        public Sale? Sale { get; set; }
        public Payment? Payment { get; set; }
        public Billing? Billing { get; set; }

        public List<SaleItem> SaleItems { get; set; } = new();
    }
}