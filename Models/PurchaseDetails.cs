using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class PurchaseDetails {

        public int PurchaseDetailId { get; set; }

        private int? _purchaseId;
        public int? PurchaseId {
 
            get => _purchaseId;
 
            set {
 
                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Purchase ID must be a positive integer or null.");
 
                _purchaseId = value;
            }
        }

        private int? _medicineId;
        public int? MedicineId {
 
            get => _medicineId;
 
            set {
 
                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Medicine ID must be a positive integer or null.");
 
                _medicineId = value;
            }
        }

        private int _quantity;
        public int Quantity {
 
            get => _quantity;
 
            set {
 
                if (value <= 0)
                    throw new ArgumentException("Quantity must be a positive integer.");
 
                _quantity = value;
            }
        }

        private decimal _unitPrice;
        public decimal UnitPrice {
 
            get => _unitPrice;
 
            set {
 
                if (value < 0)
                    throw new ArgumentException("Unit Price cannot be negative.");
 
                _unitPrice = value;
            }
        }

        public Purchase Purchase { get; set; }
        public Medicine Medicine { get; set; }
    }
}