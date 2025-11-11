using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Purchase {

        public int PurchaseId { get; set; }

        private int? _pharmacyId;
        public int? PharmacyId {

            get => _pharmacyId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Pharmacy Id must be a positive integer or null.");

                _pharmacyId = value;
            }
        }

        private int? _supplierId;
        public int? SupplierId {

            get => _supplierId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Supplier Id must be a positive integer or null.");

                _supplierId = value;
            }
        }

        private DateTime _purchaseDate;
        public DateTime PurchaseDate {

            get => _purchaseDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentException("Purchase date cannot be in the future.");

                _purchaseDate = value;
            }
        }

        private decimal _discount;
        public decimal Discount {

            get => _discount;

            set {

                if (value < 0)
                    throw new ArgumentException("Discount cannot be negative.");

                _discount = value;
            }
        }

        private int? _paymentMethodId;
        public int? PaymentMethodId {
 
            get => _paymentMethodId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Payment Method ID must be a positive integer or null.");

                _paymentMethodId = value;
            }
        }

        private byte _status;
        public byte Status {

            get => _status;

            set {

                if (value < 0 || value > 3)
                    throw new ArgumentException("Status must be between 0 and 3.");

                _status = value;
            }
        }

        private int? _createdBy;
        public int? CreatedBy {

            get => _createdBy;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Created By must be a positive integer or null.");

                _createdBy = value;
            }
        }

        private string? _note;
        public string? Note {

            get => _note;

            set {

                if (value != null && value.Length > 255)
                    throw new ArgumentException(nameof(Note), "Note cannot exceed 255 characters.");

                _note = value;
            }
        }

        private DateTime _createdDate;
        public DateTime CreatedDate {

            get => _createdDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentException("Created Date cannot be in the future.");

                _createdDate = value;
            }
        }

        public Pharmacy Pharmacy { get; set; }
        public Supplier Supplier { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public User User { get; set; }
    }
}