using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {

    public class PaymentMethod {

        // PaymentMethodId is generated automatically by the database
        public int? PaymentMethodId { get; set; }

        private string _methodName = string.Empty;
        public string MethodName {

            get => _methodName;

            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("MethodName cannot be null or empty.");

                if (value.Length > 50)
                    throw new ArgumentException("MethodName cannot exceed 50 characters.");

                _methodName = value;
            }
        }

        private string? _description;
        public string? Description {

            get => _description;

            set {
                
                if (value != null && value.Length > 255)
                    throw new ArgumentException("Description cannot exceed 255 characters.");

                _description = value;
            }
        }
    }
}