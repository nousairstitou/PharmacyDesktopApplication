using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models {

    public class Person {

        // PersonId is generated automatically by the database
        public int? PersonId { get; set; }

        private string _name = null!;
        public string Name {

            get => _name;
            
            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Name),"Name cannot be null or empty.");

                if (value.Length < 3)
                    throw new ArgumentException(nameof(Name), "Name must be at least 3 characters long.");

                _name = value;
            }
        }

        private string _phone = null!;
        public string Phone {

            get => _phone;
            
            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Phone), "Phone cannot be null or empty.");

                if (value.Length < 10)
                    throw new ArgumentException(nameof(Phone), "Phone must be at least 10 digits long.");

                _phone = value;
            }
        }

        private string? _email;
        public string? Email {

            get => _email;
            
            set {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Email) ,"Email cannot be null or empty.");

                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException(nameof(Email), "Invalid email format.");

                _email = value;
            }
        }

        private int? _addressId;
        public int? AddressId {

            get => _addressId;

            set {

                if (!value.HasValue || value <= 0)
                    throw new ArgumentException("AddressId must be a positive integer or null.");

                _addressId = value;
            }
        }

        public Address? PersonAddress { get; set; }
    }
}