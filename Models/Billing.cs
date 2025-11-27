using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Billing {

        // BillingId is generated automatically by the database
        public int? BillingId { get; set; }

        private DateTime _billingDate;
        public DateTime BillingDate {

            get => _billingDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentOutOfRangeException(nameof(BillingDate), "Billing date cannot be in the future.");
                
                _billingDate = value;
            }
        }

        private int _createdBy;
        public int CreatedBy {

            get => _createdBy;

            set {

                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(CreatedBy), "CreatedBy must be a valid user Id.");
                
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

        public DateTime CreatedAt { get; set; }

        private int _paymentId;
        public int PaymentId {

            get => _paymentId;

            set {

                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(PaymentId), "PaymentId must be a positive integer.");

                _paymentId = value;
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

        public bool IsDeleted { get; set; }

        public Sale Sale { get; private set; }
        public User User { get; private set; }
    }
}