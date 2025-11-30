using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Sale {

        public int? SaleId { get; set; }

        private int _customerId;
        public int CustomerId {

            get => _customerId;

            set {

                if(value <= 0)
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

        private byte _status;
        public byte Status {

            get => _status;

            set {

                if(value < 0 || value > 3)
                    throw new ArgumentOutOfRangeException(nameof(Status) ,"Status must be between 0 and 3.");

                _status = value;
            }
        }

        private string? _note;
        public string? Note {

            get => _note;

            set {

                if(value != null && value.Length > 255)
                    throw new ArgumentOutOfRangeException(nameof(Note) ,"Note cannot exceed 255 characters.");

                _note = value;
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

        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }

        public Customer Customer { get; private set; }
    }
}