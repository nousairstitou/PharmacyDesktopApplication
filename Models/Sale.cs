using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Sale {

        public int? SaleId { get; set; }

        private int? _customerId;
        public int? CustomerId {

            get => _customerId;

            set {

                if(!value.HasValue || value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(CustomerId), "Customer Id must be greater than zero.");

                _customerId = value;
            }
        }

        private DateTime _saleDate;
        public DateTime SaleDate {

            get => _saleDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentOutOfRangeException(nameof(SaleDate) ,"Sale date cannot be in the future.");
                
                _saleDate = value;
            }
        }

        private decimal _totalAmount;
        public decimal TotalAmount {

            get => _totalAmount;

            set {

                if(value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(TotalAmount) ,"Total Amount must be greater than zero.");

                _totalAmount = value;
            }
        }

        private decimal _amountPaid;
        public decimal AmountPaid {

            get => _amountPaid;

            set {

                if (value <= 0)
                    throw new ArgumentException(nameof(AmountPaid) ,"Amount Paid must be greater than zero.");

                if (_totalAmount > 0 && value > _totalAmount)
                    throw new ArgumentException(nameof(AmountPaid) ,"Amount Paid cannot exceed Total Amount.");

                _amountPaid = value;
            }
        }

        public Customer Customer { get; private set; }
    }
}