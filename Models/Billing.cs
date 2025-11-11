using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Billing {

        // BillingId is generated automatically by the database
        public int? BillingId { get; set; }
        
        private int? _saleId;
        public int? SaleId {

            get => _saleId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(SaleId),"Sale Id must be greater than zero.");

                _saleId = value;
            }
        }

        private DateTime _billingDate;
        public DateTime BillingDate {

            get => _billingDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentOutOfRangeException(nameof(BillingDate), "Billing date cannot be in the future.");
                
                _billingDate = value;
            }
        }

        private decimal _discount;
        public decimal Discount {

            get => _discount;

            set {

                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Discount), "Discount cannot be negative.");
                
                _discount = value;
            }
        }

        private int? _createdBy;
        public int? CreatedBy {

            get => _createdBy;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(CreatedBy), "CreatedBy must be a valid user ID.");
                
                _createdBy = value;
            }
        } 

        private string? _note;
        public string? Note {

            get => _note;

            set {

                if (value != null && value.Length < 10)
                    throw new ArgumentException("Note must be at least 10 characters long if provided.");

                _note = value;
            }
        }

        public Sale Sale { get; private set; }
        public User User { get; private set; }
    }
}