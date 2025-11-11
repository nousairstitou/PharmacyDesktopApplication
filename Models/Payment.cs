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

        private decimal _totalAmount;
        public decimal TotalAmount {

            get => _totalAmount;

            set {

                if(value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(TotalAmount) ,"Total Amount must be greater than zero.");

                _totalAmount = value;
            }
        }

        private string? _note;
        public string? Note {

            get => _note;

            set {

                if (value != null && value.Length > 255)
                    throw new ArgumentException(nameof(Note) ,"Note cannot exceed 255 characters.");

                _note = value;
            }
        }

        public Sale Sale { get; private set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}