using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class Invoice {

        public int InvoiceId { get; set; }

        private int? _purchaseId;
        public int? PurchaseId {

            get => _purchaseId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("Purchase ID must be a positive integer or null.");

                _purchaseId = value;
            }
        }

        private string _invoiceNumber = string.Empty;
        public string InvoiceNumber {

            get => _invoiceNumber;

            set {

                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invoice Number cannot be null or empty.");

                _invoiceNumber = value;
            }
        }

        private DateTime _invoiceDate;
        public DateTime InvoiceDate {

            get => _invoiceDate;

            set {

                if (value > DateTime.Now)
                    throw new ArgumentException("Invoice Date cannot be in the future.");

                _invoiceDate = value;
            }
        }

        private string? _notes;
        public string? Note {

            get => _notes;

            set {

                if (value != null && value.Length > 255)
                    throw new ArgumentException("Note cannot exceed 255 characters.");

                _notes = value;
            }
        }

        public Purchase Purchase { get; set; }
    }
}