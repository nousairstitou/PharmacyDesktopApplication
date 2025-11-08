using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class SaleDetails {

        // BillingId is generated automatically by the database
        public int? BillingId { get; private set; }

        private int? _saleId;
        public int? SaleId {

            get => _saleId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("SaleId must be a positive integer or null.");

                _saleId = value;
            }
        }

        private int? _medicineId;
        public int? MedicineId {

            get => _medicineId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("MedicineId must be a positive integer or null.");

                _medicineId = value;
            }
        }

        private int _quantity;
        public int Quantity {

            get => _quantity;

            set {

                 if (value <= 0)
                    throw new ArgumentException("Quantity must be greater than zero.");


                _quantity = value;
            }
        }

        private decimal _unitPrice;
        public decimal UnitPrice {

            get => _unitPrice;

            set {

                if (value < 0)
                    throw new ArgumentException("Unit Price must be positive.");
                
                _unitPrice = value;
            }
        }

        public Sale sale { get; private set; }
        public Medicine medicine { get; private set; }
    }
}