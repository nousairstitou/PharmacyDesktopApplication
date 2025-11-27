using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models {
   
    public class Payment {

        public int? PaymentId { get; set; }

        private int? _saleId;
        public int? SaleId {

            get => _saleId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(SaleId),"Sale Id must be greater than zero.");

                _saleId = value;
            }
        }

        private int? _paymentMethodId;
        public int? PaymentMethodId {

            get => _paymentMethodId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(PaymentMethodId),"PaymentMethod Id must be greater than zero.");

                _paymentMethodId = value;
            }
        }

        private DateTime _paymentDate;
        public DateTime PaymentDate {

            get => _paymentDate;

            set {

                if(value.Date !=  DateTime.Today)
                    throw new ArgumentOutOfRangeException(nameof(PaymentDate),"Payment date must be today's date.");

                _paymentDate = value;
            }
        }

        private decimal _amountPaid;
        public decimal AmountPaid {

            get => _amountPaid;

            set {

                if(value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(AmountPaid) , "Amount Paid must be greater than zero.");

                _amountPaid = value;
            }
        }

        private byte _status;
        public byte Status {

            get => _status;

            set {

                if (value < 0 || value > 3)
                    throw new ArgumentOutOfRangeException(nameof(Status), "Status must be between 0 and 3.");

                _status = value;
            }
        }

        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Sale Sale { get; private set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}